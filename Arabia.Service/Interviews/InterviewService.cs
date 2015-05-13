using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arabia.Core.Data;
using Arabia.Core.Domain.Interviews;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Arabia.Service.Interviews
{
    public class InterviewService : IInterviewService
    {
        #region Fields

        private readonly IMongoRepository<Interview> _interviewRepository;

        #endregion

        #region Ctor

        public InterviewService(IMongoRepository<Interview> interviewRepository)
        {
            this._interviewRepository = interviewRepository;
        }

        #endregion

        #region Methods

        public Interview GetInterviewById(ObjectId interviewId)
        {
            return _interviewRepository.GetById(interviewId);
        }

        public IList<Interview> GetInterviews()
        {
            return _interviewRepository.Collection.ToList();
        }
        public IList<Interview> GetInterviewsBySpec(string title)
        {
            var regex = new BsonRegularExpression("/" + title + "/");
            var query = Query<Interview>.Matches(e => e.Title, regex);
            return _interviewRepository.GetByQuery(query);
        }

        public bool AddInterview(Interview interview)
        {
            if (interview == null)
                throw new ArgumentNullException("Invalid Interview");
            return _interviewRepository.Add(interview);
        }

        public bool UpdateInterview(Interview interview)
        {
            if (interview == null)
                throw new ArgumentNullException("Invalid Interview");
            return _interviewRepository.Update(interview);
        }

        public bool UpdateInterviewViews(ObjectId interviewId)
        {
           return _interviewRepository.Increment(e => e.Views, interviewId);
        }
        public bool RemoveInterview(ObjectId interviewId)
        {
            return _interviewRepository.Remove(interviewId);
        }

        #endregion

    }
}
