# Application Xamarin Forms de gestion d'étudiant réalisée comme mini-projet du module C#/.Net Avancé.

_4e Année GINF Ensa safi 2018_

## Partie 1: Architecture

L'application que nous avons réalisée reprend essentiellement les mêmes éléments du cahier de charge du projet WPF, le plus important pour ce projet c'était d'acquerir les bases du developpement d'une application mobile avec Xamarin.
**Ainsi, Notre application aura l'arborescence suivante:**

* Une Page de Login: qui permet de se connecter à l'application, puis elle nous redirige vers la page Principale.

* Une Page Principale (MainPage) permettant de se rendre aux différentes Pages de Navigation suivantes:
* `EtudiantPagePrincipale` : qui affiche la liste des etudiants inscrits et permet de les supprimer, 
            ou de se rendre sur les pages:
  * Ajout d'Etudiant
  * Modification d'Etudiant

* `FilierePagePrincipale` : qui affiche la liste des filères et permet via un menu contextuel de les supprimer et des modifier. Elle permet ausi de se rendre sur la page suivant:

  * Ajout de Nouvelle Filière.
* `StatistiquePage`: qui permet d'afficher les statistiques d'étudiants par filière.


## Partie 2: Etape d'implémentation

L'implémentation de cette application s'est déroulée dans ses grandes lignes ainsi:

* Apprentissage rapide de la mise sur pied d'un projet xamarin form (via youtube)

* Mise en place du projet, installation des paquets communs et création d'une master branch sur github 
        avec le projet dans son état actuel.
* Mise en place de la Base de donnée SQLITE (PCL) et Partage des tâches comme suit:
  * Première équipe de deux personnes: Chargée de créer le module (front-end et back-end) de login 
            ainsi que celui de des statistiques 
  * Deuxième équipe de deux personnes: chargée de créer le module de gestion d'étudiants,
             une personne s'occupant du back-end et l'autre du front-end
  * Troisième équipe de deux personnes: Chargée de créer le module de gestion de Filière, 
            une personne s'occupant du back-end et l'autre du front-end
* Réalisation des tâches assignées aux sous-équipes.
* Merge des différentes branches sur github et création de l'application complète.
* Redaction du rapport technique.

![alt text](https://github.com/WilChrist/App4/blob/master/29993753_1296062597209382_175175237_o.png)
![alt text](https://github.com/WilChrist/App4/blob/master/31135880_1310386472443661_606139119_o.png)
