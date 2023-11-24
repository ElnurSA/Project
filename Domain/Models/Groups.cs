using System;
namespace Domain.Models
{
	public class Groups : BaseEntity
	{
		public string Name { get; set; }
		public int Capacity { get; set; }
	}
}

