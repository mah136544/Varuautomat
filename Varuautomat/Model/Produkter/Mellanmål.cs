using System;
using System.Collections.Generic;
using System.Text;
using Varuautomat.Model;

namespace Varuautomat.Model.Produkter
{
	public class Mellanmål : Produkt, INfo
	{
		public Mellanmål(string namn, int önskatPris)
		{
			Namn = namn;
			Pris = önskatPris;
		}
		public string NäringsInformation()
		{
			return "Mycket protein och kolhydrater";
		}
		public override string Examine()
		{
			return "Innehåller fibrer och kolhydrater";
		}
		public override string Use()
		{
			return "Bra Valt !";
		}
	}
}