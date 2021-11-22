using System;
namespace Livrable
{
    public class Save
	{
		public string appellation;
		public static DateTime horodatage;
		public EnumStates etat = new EnumStates();
		public int nbFichiersEligibles;
		public int tailleFichiers;

		public Save(string appellationADonner, EnumStates etatADonner, int nbFichiersADonner, int tailleADonner)
		{
			this.appellation = appellationADonner;
			horodatage = DateTime.Now;
			this.etat = etatADonner;
			this.nbFichiersEligibles = nbFichiersADonner;
			this.tailleFichiers = tailleADonner;
		}
	}
}