using System;
using Domain.Models;

namespace Repository.Data
{     
	public class AppDbContext<T> where T : BaseEntity
	{
		public static List<T> data = new List<T>();
    }
}

