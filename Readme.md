# 📝 TodoApp

> **Une application Todo CRUD **, développée avec **ASP.NET Core MVC**, mettant en avant une **architecture propre**, les **principes SOLID** et une **expérience utilisateur soignée**.  
>  
> 🔹 Particularité : la persistance des données repose sur **les sessions ASP.NET Core**, pour comprendre la gestion de l’état dans une application web.

---

## 📚 Table des matières

- [📌 Qu'est-ce que StatefulTodoApp ?](#-quest-ce-que-statefultodoapp-)
- [🏗️ Architecture et principes de conception](#️-architecture-et-principes-de-conception)
- [🎨 Interface utilisateur (UI/UX)](#-interface-utilisateur-uiux)
- [🔐 Authentification et autorisation](#-authentification-et-autorisation)
- [🧾 Journalisation et middleware](#-journalisation-et-middleware)
- [📸 Captures d’écran](#-captures-décran)

---

## 📌 Qu'est-ce que StatefulTodoApp ?

**TodoApp** est une application web de gestion de tâches (**Todo**) permettant aux utilisateurs de :

- ➕ Créer des tâches  
- 📋 Consulter la liste des tâches  
- ✏️ Modifier des tâches existantes  
- 🗑️ Supprimer des tâches  

💡 **Spécificité clé** :  
Cela fait de ce projet un **excellent support d’apprentissage** pour comprendre :
- la notion de **state**,
- le fonctionnement des sessions,
- et les limites/avantages d’une approche stateful.

---

## 🏗️ Architecture et principes de conception

L’application respecte rigoureusement les **bonnes pratiques de conception logicielle** :

### 🔹 Principes SOLID
- **SRP (Single Responsibility Principle)**  
  Chaque composant a une responsabilité claire et unique :
  - **Controllers** : gestion des requêtes HTTP et orchestration.
  - **Services** : encapsulation de la logique métier.
  - **ViewModels** : transport et mise en forme des données pour les vues.
  - **Views** : affichage uniquement (aucune logique métier).

### 🔹 Inversion de Dépendances (DI)
- Utilisation complète du **conteneur DI natif d’ASP.NET Core**.
- Les services ( gestion des Todos, session) sont injectés.
- Résultat :
  - 🔗 Couplage faible
  - 🧼 Code plus maintenable

---

## 🎨 Interface utilisateur (UI/UX)

L’expérience utilisateur est un axe central du projet :

- 🎯 **Moderne et intuitive**  
  - Basée sur **Bootstrap 5**
  - Palette de couleurs verte inspirante

- 📱 **Responsive et accessible**  
  - Adaptée aux mobiles, tablettes et desktops
  - Icônes **Font Awesome** pour une meilleure lisibilité des actions

- 💬 **Feedback utilisateur (Flash Messages)**  
  - Système de **flash messages** (succès, erreur, avertissement)
  - Affichés dans des **modales élégantes et non intrusives**
  - Retour clair et immédiat après chaque opération CRUD

---

## 🔐 Authentification et autorisation

Le projet explore **deux approches d’authentification**, réparties par branches :

### 🌿 Branche `main` — Authentification par session
- Approche simple et pédagogique
- Un utilisateur est considéré comme connecté si une **clé spécifique existe dans la session**


### 🚀 Branche `features/add-authentication-real` — Authentification  par claims
- Approche **robuste et prête pour la production**
- Basée sur :
  - les mécanismes standards d’ASP.NET Core
  - un **schéma de claims personnalisé**
- Gestion des rôles et permissions

---

## 🧾 Journalisation et middleware

Afin d’assurer une **traçabilité complète** :

- 🔍 Mise en place d’un **filtre d’action global**
- Chaque action exécutée par un contrôleur est automatiquement journalisée
- Informations tracées :
  - contrôleur
  - action
  - utilisateur
  - paramètres
- Ces informations sont stocker dans dossier Logs/

---


---

## 📸 Captures d’écran

> _(À remplacer par vos propres captures d’écran)_

### 🌞 Mode clair
Interface principale avec la liste des tâches en thème clair.

### 🌙 Mode sombre
Application basculée en mode sombre pour un confort visuel optimal.

### ➕ Page de création
Formulaire intuitif pour ajouter une nouvelle tâche.

### 📋 Liste des tâches
Vue d’ensemble avec indicateurs visuels de statut et d’urgence.

---

✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 
✨ 

