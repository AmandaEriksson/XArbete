using System.Collections;
using System.Collections.Generic;
using XArbete.Domain.Models;

namespace XArbete.Web.Services.Interfaces
{
    public interface IContentService : IServiceBase<Content>
    {
        public List<ContentSection> GetSections(int kennelContentId);
        public List<ContentSection> GetAllSections();

    }
}
