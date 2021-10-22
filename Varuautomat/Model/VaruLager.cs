using System;
using System.Collections.Generic;
using System.Text;
using Varuautomat.Model;
using Varuautomat.Model.Produkter;



namespace Varuautomat.Model
{
	public enum Produkttyper
	{
		dricka,
		mellanmål,
		choklad
	}

	public class Varulager
	{
		// Produkt[] varulager;
		Dictionary<Produkt, int> varulager;

		public Varulager()
		{
			/// this.varulager = new Produkt[0];
			varulager = new Dictionary<Produkt, int>();   ///  Produkt som finns på lagret

			this.varulager.Add(new Dryck("Coca Cola", 12), 20);
			this.varulager.Add(new Dryck("Vatten", 8), 120);
			this.varulager.Add(new Dryck("Redbul", 8), 120);
			this.varulager.Add(new Dryck("Fanta", 12), 20);

			this.varulager.Add(new Mellanmål("Chips", 10), 20);
			this.varulager.Add(new Mellanmål("Knäckebröd", 30), 20);
			this.varulager.Add(new Mellanmål("Äpple", 10), 20);

			this.varulager.Add(new Choklad("Kekx", 20), 50);
			this.varulager.Add(new Choklad("Marabou", 20), 50);
			this.varulager.Add(new Choklad("Aladin", 20), 50);

			
		}
		public Dictionary<Produkt, int> GetVarulager()
        {
			return varulager;
        }

		public Produkt[] AllaProdukter()
		{
			Produkt[] allaProdukter = new Produkt[varulager.Count];
			int i = 0;
			foreach (KeyValuePair<Produkt, int> post in varulager)
				allaProdukter[i++] = post.Key;
			return allaProdukter;
		}
		public Produkt[] VissaProdukter(Produkttyper söktTyp)
		{
			Produkt[] vissaProdukter = new Produkt[0];
			foreach (KeyValuePair<Produkt, int> post in varulager)
			{
				bool träff = false;
				switch (söktTyp)
				{
					case Produkttyper.dricka:
						if (post.Key is Dryck)
						{
							träff = true;
						}
						break;
					case Produkttyper.mellanmål:
						if (post.Key is Mellanmål)
						{

							träff = true;
						}
						break;
					case Produkttyper.choklad:
						if (post.Key is Choklad)
						{
							träff = true;
						}
						break;
					
                  }
				if (träff)
				{
					Produkt[] utökad = new Produkt[vissaProdukter.Length + 1];
					Array.Copy(vissaProdukter, utökad, vissaProdukter.Length);
					utökad[vissaProdukter.Length] = post.Key;
					vissaProdukter = utökad;
				}
			}
			return vissaProdukter;
		}

		public string[] AllaProduktersNamn()
		{
			string[] produkter = new string[varulager.Count];
			int i = 0;
			foreach (KeyValuePair<Produkt, int> post in varulager)
				produkter[i++] = post.Key.Namn;
			return produkter;
		}
		public string[] VissaProduktersNamn(Produkttyper söktTyp)
		{
			string[] namnen = new string[0];
			foreach (KeyValuePair<Produkt, int> post in varulager)
			{
				bool träff = false;
				switch (söktTyp)
				{
					case Produkttyper.dricka:
						if (post.Key is Dryck)
						{
							träff = true;
						}
						break;
					case Produkttyper.mellanmål:
						if (post.Key is Mellanmål)
                        {
							träff = true;
                        }
						break;
					case Produkttyper.choklad:
						if (post.Key is Choklad)
						{
							träff = true;
						}
						break;
				}
				if (träff)
				{
					string[] utökad = new string[namnen.Length + 1];
					Array.Copy(namnen, utökad, namnen.Length);
					utökad[namnen.Length] = post.Key.Namn;
					namnen = utökad;
				}
			}
			return namnen;
		}

		/// <summary>iterering över enbart en viss produkttyp
		/// </summary>
		public string[] AllaProduktersNamn(Produkttyper söktTyp)
		{
			string[] produkter = new string[0];
			string namn = "";

			foreach (KeyValuePair<Produkt, int> post in varulager)
			{
				bool träff = false;
				switch (söktTyp)
				{
					case Produkttyper.dricka:
						if (post.Key is Dryck)
						{
							träff = true;
							namn = post.Key.Namn;
						}
						break;
					case Produkttyper.mellanmål:
						if (post.Key is Mellanmål)
						{
							träff = true;
							namn = post.Key.Namn;
						}
						break;



					case Produkttyper.choklad:
						if (post.Key is Choklad)
						{
							träff = true;
							namn = post.Key.Namn;
						}
						break;
				}

				if (träff)
				{
					string[] förlängd = new string[produkter.Length + 1];
					Array.Copy(produkter, förlängd, produkter.Length);
					förlängd[produkter.Length] = namn;
					produkter = förlängd;
					träff = false;
				}
			}
			return produkter;
		}

		/// <summary>kontrollera bara om produkt finns strunta i type av produkt eller antal
		public bool finnsProdukten(string namn)
		{
			foreach (KeyValuePair<Produkt, int> post in varulager)
			{
				if (post.Key.Namn == namn)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>Mata fram produkten
		/// </summary>
		public Produkt levereraProdukt(string namn)
		{
			foreach (KeyValuePair<Produkt, int> post in varulager)
				if (post.Key.Namn == namn)
					return post.Key;

			throw new ArgumentException("Obefintlig produkt");  // produkten måste finnas
		}

		/// <summary> produktens pris
		/// </summary>
		public int pris(string namn)
		{
			foreach (KeyValuePair<Produkt, int> post in varulager)
				if (post.Key.Namn == namn)
					return post.Key.Pris;

			throw new ArgumentException("Obefintlig produkt");  // produkten måste finnas
		}
	}
}
