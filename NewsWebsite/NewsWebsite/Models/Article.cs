﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsWebsite.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int NumOfLikes { get; set; }
        public string ImageLink { get; set; }
        public string ArticleLink { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Source { get; set; }

        public string shortString(string input, int limit)
        {
            if (input.Length < limit)
                return input;
            else
                return input.Substring(0, limit) + "...";

        }

        public string lastUpdated(DateTime time)
        {
            double newTime = (DateTime.Now - time).TotalMinutes;
            if(newTime <= 1)
                return "Last updated just now";
            else if(newTime > 1 && newTime < 60 )
                return "Last updated " + (int)newTime + " mins ago";
            else if(newTime >= 60 && newTime < 1440)
            {
                return "Last updated " + (int)(newTime/60) + " hours ago";
            }
            else if(newTime >= 1440)
            {
                var newDays = (DateTime.Now - time).TotalDays;
                if (newDays <= 1)
                    return "Last updated one day ago";
                else if(newDays > 1 && newDays <= 7)
                {
                    return "Last updated " + (int)newDays + " days ago";
                }
            }

            return "Last updated at " + (DateTime.Now - time).ToString("MMMM dd, yyyy");
        }
    }
}