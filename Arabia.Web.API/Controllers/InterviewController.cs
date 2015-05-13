using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Arabia.Core.Domain.Interviews;
using Arabia.Service.Interviews;
using MongoDB.Bson;

namespace Arabia.Web.API.Controllers
{
    public class InterviewController : ApiController
    {
        #region Fields

        private readonly IInterviewService _interviewService;
        
        #endregion

        #region Constructor

        public InterviewController(IInterviewService interviewService)
        {
            _interviewService = interviewService;
        }

        #endregion
        public IList<Interview> Get()
        {
            return _interviewService.GetInterviews();
        }

        public Interview Get(string id)
        {
            return _interviewService.GetInterviewById(new ObjectId(id));
        }
        public IList<Interview> GetBySpec(string title)
        {
            return _interviewService.GetInterviewsBySpec(title);
        }

        public void Post(Interview interview)
        {
            _interviewService.AddInterview(interview);
        }

        public void Put(string id, Interview interview)
        {
            interview.Id = new ObjectId(id);
            _interviewService.UpdateInterview(interview);
        }

        public void Delete(string id)
        {
            _interviewService.RemoveInterview(new ObjectId(id));
        }
    }
}