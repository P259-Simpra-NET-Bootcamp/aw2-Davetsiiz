using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpApi.Base.Model;

public abstract class BaseModel
{
		public int Id { get; set; }
		public DateTime? CreatedAt { get; set; }
		public string CreatedBy { get; set; }
	
}
