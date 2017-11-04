using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePax.Models
{
    public class Movies 
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Cast { get; set; }
        public string Description { get; set; }
        public string MovieLanguage { get; set; }
        public string CinemaName { get; set; }
        public string CinemaAddress { get; set; }
        public string Cinema => CinemaName + " " + CinemaAddress;
        public string DirectorName { get; set; }
        public DateTime ShowTime { get; set; }
        public DateTime MovieShowTime => ShowTime.ToLocalTime(); 
        public string Phone { get; set; }
        public string MovieNature { get; set; }
        public string MovieMood { get; set; }
        public string Logo { get; set; }
        public string PhotoFullPath {
            get
            {
                if (string.IsNullOrEmpty(Logo))
                {
                    return String.Empty;
                }
                return string.Format("http://webappcinema.azurewebsites.net/{0}", Logo.Substring(1));
            }
        }
        public object LogoFile { get; set; }
    }
}
