using System.Security.Claims;
using AutoFixture;
using DfE.CoreLibs.Testing.Mocks.WebApplicationFactory;
using Dfe.PersonsApi.Client;
using Dfe.PersonsApi.Client.Contracts;
using Dfe.PersonsApi.Client.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DfE.CoreLibs.Testing.Mocks.Authentication;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;
using Dfe.Academies.Domain.Constituencies;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using Dfe.Academies.Domain.ValueObjects;
using Dfe.Academies.Infrastructure;
using TrustGovernance = Dfe.Academies.Domain.Trust.TrustGovernance;

namespace Dfe.Academies.Tests.Common.Customizations
{
    public class CustomWebApplicationDbContextFactoryCustomization<TProgram, TDbContext> : ICustomization
        where TProgram : class where TDbContext : DbContext
    {
        public Action<TDbContext>? SeedAction { get; set; }

        public void Customize(IFixture fixture)
        {
            fixture.Customize<CustomWebApplicationDbContextFactory<TProgram, TDbContext>>(composer => composer.FromFactory(() =>
            {

                var factory = new CustomWebApplicationDbContextFactory<TProgram, TDbContext>()
                {
                    SeedData = SeedAction ?? DefaultSeedData,
                    ExternalServicesConfiguration = services =>
                    {
                        services.PostConfigure<AuthenticationOptions>(options =>
                        {
                            options.DefaultAuthenticateScheme = "TestScheme";
                            options.DefaultChallengeScheme = "TestScheme";
                        });

                        services.AddAuthentication("TestScheme")
                            .AddScheme<AuthenticationSchemeOptions, MockJwtBearerHandler>("TestScheme", options => { });
                    },
                    ExternalHttpClientConfiguration = client =>
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "external-mock-token");
                    }
                };
                var client = factory.CreateClient();

                var config = new ConfigurationBuilder()
                    .AddInMemoryCollection(new Dictionary<string, string?>
                    {
                        { "PersonsApiClient:BaseUrl", client.BaseAddress!.ToString() }
                    })
                    .Build();

                var services = new ServiceCollection();
                services.AddSingleton<IConfiguration>(config);
                services.AddPersonsApiClient<IConstituenciesClient, ConstituenciesClient>(config, client);
                services.AddPersonsApiClient<IEstablishmentsClient, EstablishmentsClient>(config, client);
                services.AddPersonsApiClient<ITrustsClient, TrustsClient>(config, client);

                var serviceProvider = services.BuildServiceProvider();

                fixture.Inject(factory);
                fixture.Inject(serviceProvider);
                fixture.Inject(client);
                fixture.Inject(serviceProvider.GetRequiredService<IConstituenciesClient>());
                fixture.Inject(serviceProvider.GetRequiredService<IEstablishmentsClient>());
                fixture.Inject(serviceProvider.GetRequiredService<ITrustsClient>());

                fixture.Inject(new List<Claim>());

                return factory;
            }));
        }

        private static void DefaultSeedData(TDbContext context)
        {
            if (context is MstrContext mstrContext)
            {
                if (!mstrContext.Trusts.Any() && !mstrContext.Establishments.Any() &&
                    !mstrContext.EducationEstablishmentTrusts.Any() && !mstrContext.GovernanceRoleTypes.Any() &&
                    !mstrContext.EducationEstablishmentGovernances.Any())
                {

                    // Populate Trust
                    var trust1 = new Trust
                    {
                        SK = 1,
                        Name = "Trust A",
                        TrustTypeId = mstrContext.TrustTypes.FirstOrDefault()?.SK,
                        GroupUID = "G1",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = "System",
                        UKPRN = "12345678",
                        GroupID = "TR00024"
                    };
                    var trust2 = new Trust
                    {
                        SK = 2,
                        Name = "Trust B",
                        TrustTypeId = mstrContext.TrustTypes.FirstOrDefault()?.SK,
                        GroupUID = "G2",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = "System",
                        UKPRN = "87654321",
                        GroupID = "TR00025"
                    };
                    mstrContext.Trusts.AddRange(trust1, trust2);

                    // Populate Establishment
                    var establishment1 = new Establishment
                    {
                        SK = 1,
                        EstablishmentName = "School A",
                        LocalAuthorityId = mstrContext.LocalAuthorities.FirstOrDefault()?.SK,
                        EstablishmentTypeId = mstrContext.EstablishmentTypes.FirstOrDefault()?.SK,
                        Latitude = 54.9784,
                        Longitude = -1.6174,
                        MainPhone = "01234567890",
                        Email = "schoolA@example.com",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = "System"
                    };
                    var establishment2 = new Establishment
                    {
                        SK = 2,
                        EstablishmentName = "School B",
                        LocalAuthorityId = mstrContext.LocalAuthorities.FirstOrDefault()?.SK,
                        EstablishmentTypeId = mstrContext.EstablishmentTypes.FirstOrDefault()?.SK,
                        Latitude = 50.3763,
                        Longitude = -4.1427,
                        MainPhone = "09876543210",
                        Email = "schoolB@example.com",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = "System"
                    };
                    mstrContext.Establishments.AddRange(establishment1, establishment2);

                    // Populate EducationEstablishmentTrust
                    var educationEstablishmentTrust1 = new EducationEstablishmentTrust
                    {
                        SK = 1,
                        EducationEstablishmentId = (int)establishment1.SK,
                        TrustId = (int)trust1.SK,
                    };
                    var educationEstablishmentTrust2 = new EducationEstablishmentTrust
                    {
                        SK = 2,
                        EducationEstablishmentId = (int)establishment2.SK,
                        TrustId = (int)trust2.SK,

                    };
                    mstrContext.EducationEstablishmentTrusts.AddRange(educationEstablishmentTrust1, educationEstablishmentTrust2);

                    // Populate GovernanceRoleType
                    var governanceRoleType1 = new GovernanceRoleType
                    { SK = 1, Name = "Chair of Governors", Modified = DateTime.UtcNow, ModifiedBy = "System" };
                    var governanceRoleType2 = new GovernanceRoleType
                    { SK = 2, Name = "Vice Chair of Governors", Modified = DateTime.UtcNow, ModifiedBy = "System" };
                    var governanceRoleType3 = new GovernanceRoleType
                    { SK = 3, Name = "Trustee", Modified = DateTime.UtcNow, ModifiedBy = "System" };
                    mstrContext.GovernanceRoleTypes.AddRange(governanceRoleType1, governanceRoleType2, governanceRoleType3);

                    // Populate EducationEstablishmentGovernance
                    var governance1 = new EducationEstablishmentGovernance
                    {
                        SK = 1,
                        EducationEstablishmentId = establishment1.SK,
                        GovernanceRoleTypeId = governanceRoleType1.SK,
                        GID = "GID1",
                        Title = "Mr.",
                        Forename1 = "John",
                        Surname = "Doe",
                        Email = "johndoe@example.com",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = "System"
                    };
                    var governance3 = new EducationEstablishmentGovernance
                    {
                        SK = 3,
                        EducationEstablishmentId = establishment1.SK,
                        GovernanceRoleTypeId = governanceRoleType2.SK,
                        GID = "GID2",
                        Title = "Ms.",
                        Forename1 = "Anna",
                        Surname = "Smith",
                        Email = "annasmith@example.com",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = "System"
                    };
                    mstrContext.EducationEstablishmentGovernances.AddRange(governance1, governance3);

                    // Populate TrustGovernance
                    var trustGovernance1 = new TrustGovernance
                    {
                        SK = 1,
                        TrustId = trust2.SK,
                        GovernanceRoleTypeId = governanceRoleType3.SK,
                        GID = "GID1",
                        Title = "Mr.",
                        Forename1 = "John",
                        Surname = "Wood",
                        Email = "johnWood@example.com",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = "System"
                    };
                    var trustGovernance2 = new TrustGovernance
                    {
                        SK = 2,
                        TrustId = trust2.SK,
                        GovernanceRoleTypeId = governanceRoleType3.SK,
                        GID = "GID1",
                        Title = "Mr.",
                        Forename1 = "Joe",
                        Surname = "Wood",
                        Email = "joeWood@example.com",
                        Modified = DateTime.UtcNow,
                        ModifiedBy = "System"
                    };
                    mstrContext.TrustGovernances.AddRange(trustGovernance1, trustGovernance2);

                    // Save changes
                    mstrContext.SaveChanges();
                }
            }

            if (context is MopContext mopContext)
            {
                var memberContact1 = new MemberContactDetails(
                    new MemberId(1),
                    1,
                    "test1@example.com",
                    null
                );

                var memberContact2 = new MemberContactDetails(
                    new MemberId(2),
                    1,
                    "test2@example.com",
                    null
                );

                var constituency1 = new Constituency(
                    new ConstituencyId(1),
                    new MemberId(1),
                    "Test Constituency 1",
                    new NameDetails(
                        "Wood, John",
                        "John Wood",
                        "Mr. John Wood MP"
                    ),
                    DateTime.UtcNow,
                    null,
                    memberContact1
                );

                var constituency2 = new Constituency(
                    new ConstituencyId(2),
                    new MemberId(2),
                    "Test Constituency 2",
                    new NameDetails(
                        "Wood, Joe",
                        "Joe Wood",
                        "Mr. Joe Wood MP"
                    ),
                    DateTime.UtcNow,
                    null,
                    memberContact2
                );

                mopContext.Constituencies.Add(constituency1);
                mopContext.Constituencies.Add(constituency2);

                mopContext.SaveChanges();
            }
        }
    }
}
