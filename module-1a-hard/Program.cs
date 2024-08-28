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
int[] playerQuantities = { 0, 0, 0, 0 };

// shop item quantities
string[] items = { "Sword", "Shield", "Leather Boots", "Bracelet" };
int[] itemPrices = { 4500, 1000, 500, 1200 };
int[] shopQuantities = { 3, 1, 2, 5 };


while (true)
{
    Console.WriteLine(" ");
    Console.WriteLine("###");
    Console.WriteLine("Welcome to the Armory! What would you like to buy?");

    Console.WriteLine(" ");
    Console.WriteLine($"You have {wallet} munny.");

    Console.WriteLine(" ");
    Console.WriteLine("We have the following items in stock:");

    // notice that the array index is just 1 less than the "choice" number we want!
    for (int i = 0; i < items.Length; i++)
    {
        Console.WriteLine($"{i + 1}    {items[i]}, {itemPrices[i]} munny. In Stock: {shopQuantities[i]}");
    }
    
    // we can also append new lines using a "carriage return" and "new line"
    Console.WriteLine("5    Leave the shop\r\n");

    string answer = Console.ReadLine();

    int answerNumber = 0;

    // TryParse makes our code more fool-proof - it won't throw an exception if the value is bad
    bool result = int.TryParse(answer, out answerNumber);

    // we can use this "actual index" as the index to check in the arrays
    int actualIndex = answerNumber - 1;

    // if we receive a 5 then we leave the store
    if (answerNumber == 5)
    {
        break;
    }
    else
    {
        // if we receive anything else, we should check to see if it's valid
        // two ways it can fail:
        // 1) if TryParse fails to get an int from the string input
        // 2) if the index is outside the bounds of the array

        if (!result || actualIndex < 0 || actualIndex >= items.Length)
        {
            Console.WriteLine("Not a valid option!");
            continue;
        }
    }

    int itemCost = itemPrices[actualIndex];

    // if we have enough money, we can buy it!
    if (wallet >= itemCost)
    {

        // if the shop has enough stock, we can buy it!
        if (shopQuantities[actualIndex] >= 1)
        {
            wallet -= itemCost;

            // add to the player inventory
            playerQuantities[actualIndex]++;

            // subtract from the shop's inventory
            shopQuantities[actualIndex]--;

            // print out a summary of the transaction
            Console.WriteLine(" ");
            Console.WriteLine($"You just bought a {items[actualIndex]} for {itemPrices[actualIndex]} munny!");

            Console.WriteLine($"You now have {wallet} munny.");

            Console.WriteLine(" ");
            Console.WriteLine("Your inventory:");
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine($"You have {playerQuantities[i]} {items[i]}.");
            }
        }
        else
        {
            Console.WriteLine($"Sorry, we are all out of {items[actualIndex]}!");
        }
    }
    else
    {
        Console.WriteLine(" ");
        Console.WriteLine("You gotta buy something or get out, pal!");
    }
}

Console.WriteLine("Bye now!");