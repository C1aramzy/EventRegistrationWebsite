using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EventRegistrationWebsite.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [Required]
        public string Title { get; set; } = "";

        public string? Summary { get; set; }
        public string? Description { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today;
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        public bool IsOnline { get; set; }
        public string? OnlineEventUrl { get; set; }

        public string? VenueName { get; set; }
        public string? VenueAddress { get; set; }
        public string? PostalCode { get; set; }
        public string? UnitRoom { get; set; }
        public string? CreatedByUserId { get; set; }
        public string? CreatedByName { get; set; }    
        public bool CreatedByAdmin { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public string? EventType { get; set; }
        public string? EventTypeOther { get; set; }
        public string? EventVibe { get; set; }

        public bool IsPublished { get; set; }
        public bool IsCancelled { get; set; }

        public string? BannerImagePath { get; set; }

        public DateTime LastUpdatedOn { get; set; } = DateTime.Now;

        public string? OrganizerName { get; set; }
        public string? ContactEmail { get; set; }

        public bool TicketingEnabled { get; set; }
        public int Capacity { get; set; } 
        public int MaxTicketsPerOrder { get; set; } = 4;

        public decimal TicketPriceMin { get; set; } = 0;
        public decimal TicketPriceMax { get; set; } = 0;
        public decimal TicketPriceDefault { get; set; } = 0;

        public int TicketsSold { get; set; } = 0;

        public int? DemoFillPercent { get; set; }

        public int? DemoViewsOverride { get; set; }

        public DateTime? EarlyBirdEndsOn { get; set; }
        public decimal? EarlyBirdPrice { get; set; }
        public int TotalViews { get; set; }


        [NotMapped]
        public string ComputedStatus
        {
            get
            {
                if (IsCancelled) return "Cancelled";

                var today = DateTime.Today;

                if (EndDate.Date < today) return "Completed";
                if (StartDate.Date > today) return "Upcoming";
                return "Ongoing";
            }
        }

        public string CreatedByDisplay
        {
            get
            {
                if (CreatedByAdmin) return "Event Registration Company";
                if (!string.IsNullOrWhiteSpace(CreatedByName)) return CreatedByName!;
                return "Event Registration Company";
            }
        }

    }
}
