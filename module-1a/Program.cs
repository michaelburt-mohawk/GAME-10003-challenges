// MODULE 1A CHALLENGE
//
// Design a text-based interaction with a shop that has at least 3 items in stock. You will buy one item.
// Each item has a price and a quantity. Present these options as a numbered list.
// You have a wallet with some amount of money. Make sure you have enough money to buy the item you want!
// Present a nice printout at the end detailing the transaction, and what's in your inventory.
//
// HARD CHALLENGE: Do some research and figure out how to make this code better with loops and arrays!

// things the player has
int wallet = 11450;
int playerSwords = 0;
int playerShields = 0;
int playerLeatherBoots = 0;
int playerCharmedBracelet = 0;

// shop item quantities
int swordInStock = 3;
int shieldInStock = 1;
int leatherBootsInStock = 2;
int charmedBraceletInStock = 5;

Console.WriteLine(" ");
Console.WriteLine("###");
Console.WriteLine("Welcome to the Armory! What would you like to buy?");

Console.WriteLine(" ");
Console.WriteLine($"You have {wallet} munny.");

Console.WriteLine(" ");
Console.WriteLine("We have the following items in stock:");

Console.WriteLine(" ");
Console.WriteLine($"1   Sword, 4500 munny. In Stock: {swordInStock}");
Console.WriteLine($"2   Shield, 1000 munny.In Stock: {shieldInStock}");
Console.WriteLine($"3   Leather Boots, 500 money. In Stock: {leatherBootsInStock}");
Console.WriteLine($"4   Charmed Bracelet, 1200 money. In Stock: {charmedBraceletInStock}");

Console.WriteLine(" ");
string answer = Console.ReadLine();

int answerNumber = int.Parse(answer);

int itemCost = 0;
if (answerNumber == 1) itemCost = 4500;
else if (answerNumber == 2) itemCost = 1000;
else if (answerNumber == 3) itemCost = 500;
else if (answerNumber == 4) itemCost = 1200;

// if we have enough money, we can buy it!
if (wallet >= itemCost)
{
    // notice the code duplication here... how can we make this better?
    // start thinking about loops and arrays - we haven't covered them yet though!
    if (answerNumber == 1)
    {
        // need to check the stock first
        if (swordInStock >= 1)
        {
            wallet -= itemCost;
            swordInStock--;
            playerSwords++;
        }
    }
    else if (answerNumber == 2)
    {
        if (shieldInStock >= 1)
        {
            wallet -= itemCost;
            shieldInStock--;
            playerShields++;
        }
    }
    else if (answerNumber == 3)
    {
        if (leatherBootsInStock >= 1)
        {
            wallet -= itemCost;
            leatherBootsInStock--;
            playerLeatherBoots++;
        }
    }
    else if (answerNumber == 4)
    {
        if (charmedBraceletInStock >= 1)
        {
            wallet -= itemCost;
            charmedBraceletInStock--;
            playerCharmedBracelet++;
        }
    }

    Console.WriteLine(" ");
    Console.WriteLine($"Purchase successful! You now have {wallet} munny.");

    Console.WriteLine(" ");
    Console.WriteLine("Your inventory:");
    // think about this problem: how can we format this to have
    // an "s" on everything except a quantity of 1?
    Console.WriteLine($"You have {playerSwords} swords.");
    Console.WriteLine($"You have {playerShields} shields.");
    Console.WriteLine($"You have {playerLeatherBoots} leather boots.");
    Console.WriteLine($"You have {playerCharmedBracelet} charmed bracelets.");
}
else
{
    Console.WriteLine("You gotta buy something or get out, pal!");
}

// notice this just runs once... how could we run this many times?