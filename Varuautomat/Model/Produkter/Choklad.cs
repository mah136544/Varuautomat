using System;
using System.Collections.Generic;
using System.Text;
using Varuautomat.Model;


namespace Varuautomat.Model.Produkter
{
	public class Choklad : Produkt, INfo
	{
		public Choklad(string namn, int önskatPris)
		{
			Namn = namn;
			Pris = önskatPris;
		}
		public string NäringsInformation()
		{
			return "Innehåller Nötter och 70 ";
		}
		public override string Examine()
		{
			return "MYcket kalori " + "pris " + pris;
		}
		public override string Use()
		{
			return "DU blir tjock men om du vill bli glad ,Ät upp den !";
		}
	}
}