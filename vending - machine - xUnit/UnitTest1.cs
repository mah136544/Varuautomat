using System;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using Varuautomat.Model;
using Varuautomat.Model.Produkter;




namespace vending___machine___xUnit
{
    public class ExisteradeVaror
    {
    
    [Theory]
    [InlineData ("Coca Cola")]
    [InlineData("Vatten")]
    [InlineData("Chips")]
    [InlineData("Kekx")]
    public void FinnsIlager(string namn)
        {
            //Arrang
            Varulager varulagr = new Varuautomat.Model.Varulager();

            //Act

            string[] allaProdukter = varulagr.AllaProduktersNamn();

            //Assert
            Assert.Contains(namn, allaProdukter);
        }

        [Fact]
        public void FinnsIlagerNotNull()
        {
            //Arrang
            Varulager varulagr = new Varuautomat.Model.Varulager();
            //Act

            //Assert
            Assert.NotNull(varulagr.GetVarulager());
        }

        public class InteExisteradeVaror
        {

            [Theory]
            [InlineData("Cider")]
            [InlineData("Ketchap")]
            [InlineData("Skorpa")]
            [InlineData("Dajm")]
            public void FinnsInteIlager(string namn)
            {
                //Arrang
                Varulager varulagr = new Varuautomat.Model.Varulager();

                //Act

                string[] allaProdukter = varulagr.AllaProduktersNamn();

                //Assert
                Assert.DoesNotContain(namn, allaProdukter);
            }
            public class FelBetalning
            {
            //Mynt
            [Theory]
            [InlineData ("norskKrona")]
            [InlineData("dansKrona")]
            public void InteAcceptMynt(string val�r)
                {
                    //Arrang
                    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();

                    //Act

                    bool resultat = accepteradeBetalningsmedel.accepterasMyntet(val�r);

                    //Assert
                    Assert.False(resultat);
                
                }

            }

            //Sedlar
            [Theory]
            [InlineData("Dollar")]
            [InlineData("Euro")]
            public void InteAcceptSedlar(string val�r)
            {
                //Arrang
                AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();

                //Act

                bool resultat = accepteradeBetalningsmedel.accepterasSedeln(val�r);

                //Assert
                Assert.False(resultat);

            }
            public class R�ttBetalning
            {
                //Mynt
                [Theory]
                [InlineData("5-krona")]
                [InlineData("10-krona")]
                public void AcceptMynt(string val�r)
                {
                    //Arrang
                    AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();

                    //Act

                    bool resultat = accepteradeBetalningsmedel.accepterasMyntet(val�r);

                    //Assert
                    Assert.True(resultat);

                }

            }

            //Sedlar
            [Theory]
            [InlineData("Astrid")]
            [InlineData("Ingmar")]
            public void AcceptSedlar(string val�r)
            {
                //Arrang
                AccepteradeBetalningsmedel accepteradeBetalningsmedel = new AccepteradeBetalningsmedel();

                //Act

                bool resultat = accepteradeBetalningsmedel.accepterasSedeln(val�r);

                //Assert
                Assert.True(resultat);

            }

        }


    }


}

