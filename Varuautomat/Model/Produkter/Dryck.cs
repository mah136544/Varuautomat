using System;
using System.Collections.Generic;
using System.Text;
using Varuautomat.Model;



namespace Varuautomat.Model.Produkter
{
	public class Dryck : Produkt, INfo
	{
		public Dryck(string namn, int önskatPris)
		{
			Namn = namn;
			Pris = önskatPris;
		}
		public string NäringsInformation()
		{
			return " Mycket  Socker. Citronsyra";
		}
		public override string Examine()
		{
			return "Mycket soker. Ska drickas";
		}
		public override string Use()
		{
			return "Om du vill. Skål";
		}
	}
}