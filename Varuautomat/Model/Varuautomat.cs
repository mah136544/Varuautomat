using System;
using System.Collections.Generic;
using System.Text;
// varuatomat model

namespace Varuautomat.Model
{
	public class Varuautomat : IVending
	{
		private int _kundSaldo = 0;
		private int _totalFörsäljning = 0;
		private AccepteradeBetalningsmedel _accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();
		private Varulager _varulager = new Varulager();

		public int KundSaldo
		{
			get { return _kundSaldo; }
			private set { _kundSaldo = value; }
		}

		public int TotalFörsäljning
		{
			get { return _totalFörsäljning; }
			private set { _totalFörsäljning = value; }
		}

		public Varuautomat()
		{
		}

		public string[] ShowAll()
		{
			return _varulager.AllaProduktersNamn();
		}
		public string[] ShowAll(Produkttyper typ)
		{
			return _varulager.VissaProduktersNamn(typ);
		}
		public Produkt[] ShowAllProdukt()
		{
			return _varulager.AllaProdukter();
		}

		/// <summary>
		/// mata in sedlar eller mynt i fasta valörer, och kreditera kundsaldo
		/// </summary>
		public void InsertMoney(string namn)
		{
			try
			{
				if (_accepteradeBetalningsmedel.accepterasMyntet(namn))
				{
					KundSaldo = KundSaldo + _accepteradeBetalningsmedel.Värde(namn);
				}
				else if (_accepteradeBetalningsmedel.accepterasSedeln(namn))
				{
					KundSaldo = KundSaldo + _accepteradeBetalningsmedel.Värde(namn);
				}
				else
				{
					throw new ArgumentException("ej accepterad valör");  //  accepterar ej - spotta ut
				}
			}
			catch (ArgumentException)  // fel - accepterasSedeln eller accepterasMynte
			{
				throw new ArgumentException("ej accepterad valör");
			}
		}

		public Produkt Purchase(string namn)
		{
			if (_varulager.finnsProdukten(namn))
			{
				// produkten finns, debitera kundsaldo och kreditera totalFörsäljning
				KundSaldo = KundSaldo - _varulager.pris(namn);
				TotalFörsäljning = TotalFörsäljning + _varulager.pris(namn);
				return _varulager.levereraProdukt(namn);
			}
			else
			{
				throw new ArgumentException("Obefintlig produkt");  // produkten måste finnas
			}
		}

		/// <summary> räkna upp växeln och debitera kundsaldo så att det blir noll
		/// </summary>
		public Dictionary<string, int> EndTransaction()
		{
			// debitera kundsaldo
			Dictionary<string, int> växelAttÅterlämna = new Dictionary<string, int>();

			string[] pengNamn = _accepteradeBetalningsmedel.allaAccepteradeBetalningsmedel();
			// foreach (string peng in pengNamn)
			//	Console.WriteLine(peng);

			//
			// listan med betalningsmedel är sorterad i sjunkande ordning så iterera framåt i den
			//
			foreach (string peng in pengNamn)
			{
				while (_accepteradeBetalningsmedel.Värde(peng) <= KundSaldo)
				{
					if (!växelAttÅterlämna.ContainsKey(peng))
						växelAttÅterlämna.Add(peng, 0);
					växelAttÅterlämna[peng] = växelAttÅterlämna[peng] + 1;
					KundSaldo = KundSaldo - _accepteradeBetalningsmedel.Värde(peng);
					Console.WriteLine("peng: " + peng + " KundSaldo: " + KundSaldo);
				}
			}

			return växelAttÅterlämna;
		}
	}
}
