using System;
namespace Livrable
{
    public class Save
	{
		public string appellation;
		public static DateTime horodatage;
		public EnumStates etat = new EnumStates();
		public int nbFichiersEligibles;
		public double tailleFichiers;
		public string source;
		public string dest;
		CalculLenght calculTaille = new CalculLenght();
		public float tailledest;


		public Save(string appellationADonner, string source, string dest)
		{
			this.source = source;
			this.dest = dest;
			this.appellation = appellationADonner;
			horodatage = DateTime.Now;
			this.etat = EnumStates.NONACTIF;
			this.nbFichiersEligibles = calculTaille.numberfichier;
			this.tailleFichiers = calculTaille.calculateFolderSize(source);
			this.tailledest = calculTaille.calculateFolderSize(dest);
			if (tailleFichiers != tailledest) ;
		}
	}
}