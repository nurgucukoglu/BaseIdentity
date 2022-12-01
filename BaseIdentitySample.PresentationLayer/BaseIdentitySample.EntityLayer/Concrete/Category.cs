using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseIdentitySample.EntityLayer.Concrete
{
	public class Category
	{
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public  List<Product> products { get; set; }  //bir category birden fazla ürünün içinde yer olabilir. Bire çok
	}
}
