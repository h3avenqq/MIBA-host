using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIBA.Models
{
    public class MissionRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public IFormFile? Photo { get; set; }
        public string? PhotoUrl { get; set; }

        public MissionRequest()
        {

        }

        public MissionRequest(Mission mission)
        {
            Id = mission.Id;
            Title = mission.Title;
            SubTitle = mission.SubTitle;
        }
    }
}
