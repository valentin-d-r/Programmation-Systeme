# EasySave by ProSoft


Bienvenu sur cette notice utilisateur !
EasySave by ProSoft est un logiciel de sauvegarde facile, et rapide.
L'ensemble de ce document, aura pour but, de vous guidez dans l'utilisation de celui-ci.


## Selection de la langue
Au lancement de l'application, vous serez invité à entré la langue de votre choix. Vous aurez le choix entre le Francais et l'Anglais. (FR-EN)


## Nombre de travaux de sauvegarde 
L'application vous demandera le nombre de travaux de sauvegarde que vous souhaité réaliser. Un travail de sauvegarde, correspond à la sauvegarde d'un dossier.
A savoir, vous ne pouvez pas exédé 5 travaux de sauvegarde.

## Nom de la sauvegarde
Il est primordial de nommé tout vos travaux de sauvegarde, avec un nom que vous parviendrais facilement à retrouvé. 
Pour toutes les sauvegardes exécuté, un fichiers log (c.f chapitre logs) contenant l'ensemble des données de votre sauvegarde sera stocké.
Ainsi, vous pourrez facilement retrouvé une sauvegarde exécuté avec t-elle nom dans le fichier log.

## Sauvegarde (Dossier Source/Destination)
Après avoir entré le nom de votre sauvegarde, vous devrez entré le chemin source de votre dossier que vous souhaitez sauvegardé. Ensuite, vous serez invité à entré le chemin du fichier de destination.
Pour celà, il suffit de : 
  **- MAC OS :**
    _Vous devez impérativement 'Lire les informations' du dossier, puis copié le chemin. Pour ensuite le collé dans le terminal._
  **- Windows** : 
    _Vous pouvez glissé le fichier dans le terminal._
**EasySave** inlu la sauvegarde de dossiers sur : 
- Des disques locaux
- Des disques Externes
- Des Lecteurs réseaux
Dans le cas, où votre sauvegarde à bel et bien était reussi, un message console, viendra notifié de sont succès.


## Fichiers Logs

Il existe deux fichiers Logs de notre application. 

Le premier fichier **log**, vous permet d'avoir accès à l'entièreté des sauvegarde effectué grace à EasySave. 
Pour chaque sauvegarde, vous trouverez les informations suivantes : 
- Horodatage
- Appellation du travail de sauvegarde
- Adresse complète du fichier Source 
- Adresse complète du fichier de destination 
- Taille du fichier 
- Temps de transfert du fichier en ms 

Le second, **LogStates** vous permet de vérifié si une sauvegarde est toujours en cours, et de controler sont Etat.
Pour chaque sauvegarde, vous trouverez les informations suivantes :
- Appellation du travail de sauvegarde
- Horodatage
- Adresse complète du fichier Source 
- Adresse complète du fichier de destination 
- Etat du travail de Sauvegarde (0,1 ou 2)
A savoir, les états sont symbolisé par :
End : 0 
Actif : 1
Non Actif : 2

**Les fichier Logs et LogStates,** se trouve par défault dans le chemin ci contre : C:/Users/
 **Attention**, ce but de ce logiciel est la **sauvegarde** des **fichiers**, et non l'**archivage**. Le fichier **source**, ne sera donc pas **supprimé** après la **sauvegarde**.
**ProSoft CopyRight 2021**
