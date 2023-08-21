using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.Model
{
	[Table("tblCourceImg")]
	public class CourceImg
	{
		public int Id { get; set; }
		public int CourceId { get; set; }
		public string? Img { get; set; }
		public bool FirstImg { get; set; }
	}
}
