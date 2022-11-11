using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
   public interface IAcademyTransferProjectGateway
   {
      AcademyTransferProjects SaveAcademyTransferProject(AcademyTransferProjects project);
      AcademyTransferProjects GetAcademyTransferProjectByUrn(int urn);
      AcademyTransferProjects UpdateAcademyTransferProject(AcademyTransferProjects project);

      /// <summary>
      ///    Retrieves the specified page of transfer projects and the total number of projects in the database
      /// </summary>
      /// <param name="page">the page of results to return</param>
      /// <returns>
      ///    A <see cref="Tuple{IList, Int32}" /> containing the requested page of results and the total number of matching
      ///    entries in the database
      /// </returns>
      /// <remarks>
      ///    <para>Page size is hard-coded to ten</para>
      ///    <para><paramref name="page" /> is 1-based, not zero-based (Page 1 is the first entry, not page zero)</para>
      /// </remarks>
      Tuple<IList<AcademyTransferProjects>, int> IndexAcademyTransferProjects(int page);
      IEnumerable<AcademyTransferProjects> GetAcademyTransferProjects();
    }
}
