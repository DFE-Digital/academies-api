using System;
using AutoFixture;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class AcademyConversionProjectNoteResponseFactoryTests
    {
        private readonly Fixture _fixture;

        public AcademyConversionProjectNoteResponseFactoryTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void ReturnsAcademyConversionProjectNoteResponse_WhenGivenAcademyConversionProjectNote()
        {
            var projectNote = _fixture.Create<ProjectNote>();
            var response = AcademyConversionProjectNoteResponseFactory.Create(projectNote);

            response.Subject.Should().Be(projectNote.Subject);
            response.Note.Should().Be(projectNote.Note);
            response.Author.Should().Be(projectNote.Author);
            response.Date.Should().Be(projectNote.Date);
        }
    }
}
