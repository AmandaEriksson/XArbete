using XArbete.Services.Data;
using XArbete.Domain.Models;
using XArbete.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace XArbete.Services.Services
{
    public class ContentService : ServiceBase<Content>, IContentService
    {
        private IContentSectionService _contentSections;
        public ContentService(XArbeteContext context, IContentSectionService contentsections) : base(context)
        {
            _contentSections = contentsections;
        }

        public List<ContentSection> GetAllSections()
        {
            return _contentSections.GetAll().ToList();
        }

        public List<ContentSection> GetSections(int kennelContentId)
        {
            return _contentSections.GetMany(a => a.KennelContentId == kennelContentId).ToList();

        }
    }
}
