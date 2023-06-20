# Enhanced Game Vision Document for "Entrepreneur Empire: Business Simulator"

## Game Overview

Entrepreneur Empire: Business Simulator offers an immersive and compelling journey into the exhilarating sphere of
entrepreneurship. Our game enables players to helm their own enterprises, grapple with AI competitors, and navigate the
fluctuating marketplace for the ultimate taste of business success.

## Core Features

1. **Entrepreneurial Autonomy**: Players have full command over their company's operations, from production and
   marketing strategies to financing and budgeting decisions. Your strategic choices will directly influence profit
   margins and competitive standing.

2. **Dynamic Marketplace**: The lively marketplace mirrors real-world supply and demand principles, challenging players
   to manage their product lines, analyze economic trends, set competitive pricing, and control inventory strategically.

3. **Innovation Hub**: To maintain their competitive advantage, players can channel resources into research and
   development. This will drive product enhancements, optimize production processes, and unlock groundbreaking
   opportunities.

4. **Strategic Alliances**: Players can negotiate contracts and form partnerships with AI-driven companies, leveraging
   combined strengths and resources to foster reciprocal growth.

5. **Sophisticated Financial Management**: A detailed financial management system enables players to closely track their
   income, expenses, net profit, and overall balance. This will encourage informed financial decision-making, including
   securing loans and ensuring positive cash flow.

6. **Intelligent AI Rivals**: Compete against AI-driven competitors, who adjust their strategies based on evolving
   market conditions, bringing an added layer of complexity and challenge to your business venture.

7. **Quarterly Progression**: The turn-based gameplay echoes real-life business cycles, with each turn representing a
   fiscal quarter. Strategic decision-making and outcome evaluation phases fuel the game progression.

8. **Intuitive Interface and Data Visualization**: An accessible interface with intuitive controls pairs with visually
   appealing data representations. Comprehensive charts and graphs aid in strategic decision-making by simplifying
   complex data analysis.

## Target Audience

Entrepreneur Empire: Business Simulator caters to casual gamers with a curiosity for business and management themes, as
well as strategy enthusiasts who thrive on economic simulations. The game balances simplicity with depth, appealing to a
broad spectrum of players.

## Player Experience

Entrepreneur Empire aims to deliver a vivid and riveting experience, mirroring the realities of managing a business.
Players confront a variety of challenges, make critical decisions, and savor the victory of guiding their start-up to
become a global enterprise.

Player engagement is sustained by a sense of progression, realized through expanding operations, product innovation, and
strategic outmaneuvering of AI competitors. The ever-changing marketplace and advanced AI adversaries ensure
unpredictable and exciting gameplay, fostering long-term player commitment.

## Aesthetic Style and Themes

The game's aesthetic is modern and sleek, punctuated by vibrant color schemes, streamlined UI components, and graphic
elements that bring the business world to life. Entrepreneur Empire revolves around the theme of entrepreneurship,
reflecting the ambition, hurdles, and triumphs inherent in establishing and managing a prosperous business. It inspires
players to think strategically, take calculated risks, and embrace their entrepreneurial drive.

## Influences and Inspirations

- [Monopoly Tycoon](https://www.monopolytycoon.com/)
- [Game Dev Tycoon](https://www.greenheartgames.com/game-dev-tycoon/)
- [Capitalism Lab](https://www.capitalismlab.com/)
- [SimCity](https://www.ea.com/games/simcity)

## Final Thoughts

Entrepreneur Empire: Business Simulator promises a captivating and layered gaming experience for anyone intrigued by
business and entrepreneurship. With a broad range of features, a vibrant marketplace, and challenging AI competitors,
our game provides a thrilling exploration of building and operating successful companies.

please create structure for my project adapted to a buisness simulation game in unity: `Unity Style Guide
This article contains ideas for setting up a projects structure and a naming convention for scripts and assets in Unity.

Table of Contents,Introduction,Project Structure,Scripts,Asset Naming Conventions,Asset Workflows

1.1 Style
If your project already has a style guide, you should follow it.
If you are working on a project or with a team that has a pre-existing style guide, it should be respected. Any
inconsistency between an existing style guide and this guide should defer to the existing.

Style guides should be living documents however and you should propose style guide changes to an existing style guide as
well as this guide if you feel the change benefits all usages.

Arguments over style are pointless. There should be a style guide, and you should follow it.
Rebecca Murphey

All structure, assets, and code in any project should look like a single person created it, no matter how many people
contributed.
Moving from one project to another should not cause a re-learning of style and structure. Conforming to a style guide
removes unneeded guesswork and ambiguities.

It also allows for more productive creation and maintenance as one does not need to think about style, simply follow
instructions. This style guide is written with best practices in mind, meaning that by following this style guide you
will also minimize hard to track issues.

Friends do not let friends have bad style.
If you see someone working either against a style guide or no style guide, try to correct them.

When working within a team or discussing within a community, it is far easier to help and to ask for help when people
are consistent. Nobody likes to help untangle someone's spaghetti code or deal with assets with names they can't
understand.

If you are helping someone who's work conforms to a different but consistent and sane style guide, you should be able to
adapt to it. If they do not conform to any style guide, please direct them here.
2. Project Structure
   The directory structure style of a project should be considered law. Asset naming conventions and content directory
   structure go hand in hand, and a violation of either causes unneeded chaos.

In this style, we will be using a structure that relies more on filtering and search abilities of the Project Window for
those working with assets to find assets of a specific type instead of another common structure that groups asset types
with folders.

Using a prefix naming convention, using folders to contain assets of similar types such as Meshes, Textures, and
Materials is a redundant practice as asset types are already both sorted by prefix as well as able to be filtered in the
content browser.

Assets:_Developers(Use a `_`to keep this folder at the top):DeveloperName(Work in progress assets);ProjectName:
Characters:Anakin;FX:Vehicles:Abilities:IonCannon:(Particle Systems, Textures);;;Weapons;;:Gameplay:Characters,
Equipment,Input,Vehicles:Abilities,Air:TieFighter:(Models, Textures, Materials, Prefabs);;;;_Levels:Frontend,Act1:
Level1;;;Lighting:HDRI,Lut,Textures;;MaterialLibrary:Debug,Shaders;;Objects:Architecture (Single use big objects):
DeathStar;;Props (Repeating objects to fill a level):ObjectSets:DeathStar;;;Scripts:AI,Gameplay:
Input;Tools;;Sound,Characters,Vehicles:TieFighter:Abilities:Afterburners;;;;Weapons;UI:Art:Buttons;;Resources:
Fonts;;ExpansionPack (DLC),Plugins,ThirdPartySDK

The reasons for this structure are listed in the following sub-sections.

2.1 Folder Names
These are common rules for naming any folder in the content structure.

Always Use PascalCase
PascalCase refers to starting a name with a capital letter and then instead of using spaces, every following word also
starts with a capital letter. For example, DesertEagle, RocketPistol, and ASeriesOfWords.

Never Use Spaces
Re-enforcing 2.1.1, never use spaces. Spaces can cause various engineering tools and batch processes to fail. Ideally
your project's root also contains no spaces and is located somewhere such as D:\Project instead of C:\Users\My Name\My
Documents\Unity Projects.


No Empty Folders
There simply shouldn't be any empty folders. They clutter the content browser.

2.2 Use A Top Level Folder For Project Specific Assets
All of a project's assets should exist in a folder named after the project. For example, if your project is named '
Generic Shooter', all of it's content should exist in Assets/GenericShooter.

The Developers folder is not for assets that your project relies on and therefore is not project specific. See Developer
Folders for details about this.



`, find good folder structure for my scripts, maybe subfolders under the Gameplay folder in scripts? or what fits better : `
BuisnessTycoon\Assets\BusinessTycoon
BuisnessTycoon\Assets\BusinessTycoon\_Scenes
BuisnessTycoon\Assets\BusinessTycoon\_Scenes\Main.unity
BuisnessTycoon\Assets\BusinessTycoon\_Scenes\Menu.unity
BuisnessTycoon\Assets\BusinessTycoon\Prefabs
BuisnessTycoon\Assets\BusinessTycoon\Prefabs\Background.prefab
BuisnessTycoon\Assets\BusinessTycoon\Prefabs\Company.prefab
BuisnessTycoon\Assets\BusinessTycoon\Prefabs\Offer.prefab
BuisnessTycoon\Assets\BusinessTycoon\Prefabs\Product.prefab
BuisnessTycoon\Assets\BusinessTycoon\Prefabs\ProductInfoPrefab.prefab
BuisnessTycoon\Assets\BusinessTycoon\ScriptableObjects
BuisnessTycoon\Assets\BusinessTycoon\ScriptableObjects\Factories
BuisnessTycoon\Assets\BusinessTycoon\ScriptableObjects\Factories\FactorySo.cs
BuisnessTycoon\Assets\BusinessTycoon\ScriptableObjects\Panels
BuisnessTycoon\Assets\BusinessTycoon\ScriptableObjects\Panels\MarketPanel.asset
BuisnessTycoon\Assets\BusinessTycoon\ScriptableObjects\Products
BuisnessTycoon\Assets\BusinessTycoon\ScriptableObjects\Products\Basic Car.asset
BuisnessTycoon\Assets\BusinessTycoon\ScriptableObjects\Products\Green Car.asset
BuisnessTycoon\Assets\BusinessTycoon\ScriptableObjects\Products\ProductSO.cs
BuisnessTycoon\Assets\BusinessTycoon\ScriptableObjects\Products\Safe Car.asset
BuisnessTycoon\Assets\BusinessTycoon\ScriptableObjects\Products\Sporty Car.asset
BuisnessTycoon\Assets\BusinessTycoon\ScriptableObjects\Factory.asset
BuisnessTycoon\Assets\BusinessTycoon\ScriptableObjects\PlayerCompanyPreset.asset
BuisnessTycoon\Assets\BusinessTycoon\Scripts
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Interfaces
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Interfaces\IManager.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Interfaces\IPanel.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Managers
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Managers\AIManager.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Managers\GameManager.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Managers\GameState.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Managers\ManagerProvider.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Managers\MarketManager.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Managers\PanelManager.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Managers\PlayerManager.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Managers\ResolutionManager.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Managers\TurnManager.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Managers\UIManager.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Model
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Model\Company.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Model\CompanyPreset.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Model\FactoryData.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Model\Finance.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\Model\ProductData.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\States
BuisnessTycoon\Assets\BusinessTycoon\Scripts\States\TurnState.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\States\TurnStateMachine.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\UI
BuisnessTycoon\Assets\BusinessTycoon\Scripts\UI\BasePanel.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\UI\BudgetingPanel.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\UI\ContractsPanel.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\UI\FinancingPanel.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\UI\InventoryPanel.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\UI\MarketInfoPanel.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\UI\OfferPanel.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\UI\PanelData.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\UI\ProductInfo.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\UI\ProductionPanel.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\UI\ReportsPanel.cs
BuisnessTycoon\Assets\BusinessTycoon\Scripts\UI\ResearchPanel.cs`
