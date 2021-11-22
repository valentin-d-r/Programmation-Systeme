using System;
namespace Livrable
{
    public class Software
    {
		public LanguageSoft langue = new LanguageSoft();
		public int nbTravaux;
		public Software(LanguageSoft langueADefinir, int nbSouhaite)
		{
			this.langue = langueADefinir;
			this.nbTravaux = nbSouhaite;
		}

		public LanguageSoft getLangue()
		{
			return this.langue;
		}

		public void setLangue(LanguageSoft langueAModifier)
		{
			this.langue = langueAModifier;
		}

		public int getNbTravaux()
		{
			return this.nbTravaux;
		}

		public void setNbTravaux(int nbTravauxAModifier)
		{
			this.nbTravaux = nbTravauxAModifier;
		}


	}
}
