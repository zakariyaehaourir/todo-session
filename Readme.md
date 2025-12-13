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


### 🌞 Mode clair

<img width="1868" height="657" alt="list" src="https://github.com/user-attachments/assets/8cb42ca5-fa58-4ba2-9a67-d5cc0f65d7d2" />

### 🌙 Mode sombre
<img width="1868" height="732" alt="dark" src="https://github.com/user-attachments/assets/b4e01c39-fd28-45ef-8ae1-a44fb4de52ec" />


### ➕ Page de création
<img width="1850" height="894" alt="create" src="https://github.com/user-attachments/assets/3e2d3971-e78e-455b-9bda-90fe17c80e7f" />

### 📋 Liste des tâches
Vue d’ensemble avec indicateurs visuels de statut et d’urgence.

<img width="1866" height="738" alt="list2" src="https://github.com/user-attachments/assets/af95822a-aa47-40e6-9644-55a85f81b845" />


### Flash Messages
<img width="1596" height="763" alt="1" src="https://github.com/user-attachments/assets/b284d984-413b-4cbf-9a62-140cf24d689a" />


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

