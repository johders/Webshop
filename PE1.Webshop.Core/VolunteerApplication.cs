using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1.Webshop.Core
{
	public class VolunteerApplication
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string Email { get; set; }
		public DateTime ArrivalDate { get; set; }
		public DateTime DepartureDate { get; set; }
		public string Country { get; set; }
        public bool NewsLetterSignUp { get; set; }

    }
}
