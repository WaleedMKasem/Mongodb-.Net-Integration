using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arabia.Core.Domain.Interviews;
using MongoDB.Bson;

namespace Arabia.Service.Interviews
{
    public interface IInterviewService
    {
        Interview GetInterviewById(ObjectId interviewId);
        IList<Interview> GetInterviews();
        IList<Interview> GetInterviewsBySpec(string title);
        bool AddInterview(Interview interview);
        bool UpdateInterview(Interview interview);
        bool UpdateInterviewViews(ObjectId interviewId);
        bool RemoveInterview(ObjectId interviewId);
    }
}
