WARNING: Downloading this calculator to your PC can be dangerous and not recommended, even thought I assure you there are no viruses there. Do it at you're own risk. It's much safer to download it just to examine the game files.

If you still insist on downloading at, you can download the app's code and original files (and dozens of decks) here:

[https://www.mediafire.com/file/qy0timqb1f8mvnr/DBZ+Power+levels+to+Yugioh+ATK+points+converter+-+working+version+(4).zip/file](https://www.mediafire.com/file/qy0timqb1f8mvnr/DBZ+Power+levels+to+Yugioh+ATK+points+converter+-+working+version+(4).zip/file)

And you can download the same app in a proper "customer" installable version without the code files here:
https://www.mediafire.com/file/1xnzpb5dee0bloi/Yugioh_converter_installation.zip/file

As for how this app works:

This is a converter between DBZ power levels gaps (scouter numbers, etc) to Yugioh strength terms (attack and defense points of monster cards. It's a console app, working in a logic of input-output: the user inputs some variables, and the app calculates the ATK/DEF points of DBZ charachters based on those variables and the characters power levels. I only created this to make a Yugioh computer game where most monster cards are DBZ characters, which I have power levels for all of them.

While this is obviously useless for benefical stuff, the basic mathematical idea behind this, which includes (according to chatGPT) scalling factors, exponents, use of power, Logarithms, base numbers and Set theory, may be usefull for other (benefical) mathematical calulcations not related to pointless nonesense such as games or anime. Such as finance stuff.

This README text file will provide an explanation for what this application does and how it works which everyone can easily understand, without addressing the details only Yugioh and Dragon ball fans will understand. (Aside from section 9 - feel free to skip it - you don't need to read section 9 to understand what excatly this software does and how it works) Here's the explanation:

The idea is to take a groups number of gaps measured via multipliers, and convert it to another grousp numbers of gaps measured by addition-subtraction, each group has its own numerical scale (a different range of numbers), meaning each number groups has its own "minimum" and "maximum" numbers.
The meaning of "a groups number of gaps measured via multipliers, and convert it to another grousp numbers of gaps measured by addition-subtraction" can be demonstrated with the following facts-providing about both group numbers:
All number groups from both types (both the multipliers-number group and the addition/subtraction-number group) must have in advance a minimal number and a maximum number.
"Minimal number" is the lowest number allowed for each number group, while the "maximum number" is the highest allowed number for each number group.
Each group must have different own minimal and maximum numbers than all the other groups.
So this means, for example, that if a number group has a minimum number of 1 and a maximum number of 10, the number group can have (in theory) an infinite amount of numbers in it, but they must all be higher than 1 and lower than 10.
a. Now let's explain the point of what this app helps to do. Let's take random minimal/maximum numbers for each number group:

"Multiplier" number group - minimum number: 1, maximum number: 1,440,000 (2 real power levels of 2 DBZ characters)
"addition/subtraction" group - minimum number: 0, maximum number: 4,000 (typical yugioh ATK/DEF points range) in this example, the gaps in the "Multiplier" number group are (in terms of multiplication/division) 1,440,000 / 1 = x1,440,000 gap between minimum and maximum. And in the "addition/subtraction" number group, the gap between minimum and maximum is: 4,000 - 0 = 4,000.
b. Now, the idea of the app is to ensure equal gaps between the 2 groups by calculating (at a time) the "equivariant" of a number in the "multiplication/division" (Multiplier) group to a number in the "addition/subtraction" group. Those 2 numbers will never be equal. So what is considered the "equivariant" of those numbers? This:

c. In continous to the example in section e, where (quote): "- "Multiplier" number group - minimum number: 1, maximum number: 1,440,000.

"addition/subtraction" number group - minimum number: 0, maximum number: 4,000 (typical yugioh ATK/DEF points range)" Now, we now add a number to the "multiplier" number group, which must be below 1,440,000 but above 1, to calculate its ATK points "equivariant". Let's add to this number group the number: 1,200. Notice that in terms of multiplication/division, the new number (1,200) is excatly in-between - just as far ahead of the minimum number is the maximum number is to the new number. Why? Because again, in this number group the gaps are measured by multiplication/division, and the gaps between those 3 numbers is: 1,200 (new number) / 1 (minimum number) = 1,200 = x1,200 gap between them. 1,440,000 (maximum number) / 1,200 (minimum number) = 1,200 = also a x,1200 gap!
d. Now, to find the new number (1,200) "equivariant" in the "addition/subtraction" number group -

we need to find a number that is also excatly in-between the minimum number in the "addition/subtraction" number group (0) and its maxmimum number (4,000), but in terms of addition/subtraction instead of multiplication/division, since the new number's "equivariant" will be another number added to the "addition/subtraction" number group.

The number we'll find is: 2,000. the number 2,000 is the number we're looking for: it is excatly 2000 points below the maximum number (4,000 - 2,000) and also 2,000 points above the minimum number (0), just like how its "multiplication/division" number group equivariant (1,200) is x1,200 below the minimum and also x1,200 below the maximum.

(The app uses some mathematical caluclations to calculate this, that weren't described here yet, but I took an example that you guys can understand without this).

Therfore, the new number in the "multiplication/division" number group (1,200)'s "equivariant" number in the "addition/subtraction" number group is 2,000.

This number (2,000) represents, however, ONLY the new number's ATK points "equivariant". The DEF points "equivariant" of the new number are yet to be calculated. the app can also calculate the DEF points of the same new number (with has 2,000 ATK points) based on a variable of the "gap" (in multiplication/division) between the new number's value in the "multiplication/division" number group (1,200). But it's too complicated to explain at this point how the app does it, so we'll get to that later.

So this is the main goal of this console application convertor and what its supposed to do.

If you ARE a yugioh/DBZ fan and know what power levels and ATK/DEF mean, you might be able to understand why I need this software and what I do with it. If you are, than what I do is (if you aren't, skip to section 10):

a. I want to create for the Yugioh game decks of my own, most of which include only DBZ characters. b. I know the power levels of those DBZ characters. c. I want each DBZ character to represent a monster card in my game. d. I also want that the higher each DBZ character's power level is, the higher their ATK/DEF points will be. e. So, each time I create a DBZ character-based monster card, I take his power level and caluclate its ATK/DEF points "equivariant" via this console application. In the example above, the "multiplication/division" number group (): "- "Multiplier" number group (this is the DBZ power levels number group) - minimum number: 1, maximum number: 1,440,000.

"addition/subtraction" number group (this is the Yugioh ATK/DEF number group) - minimum number: 0, maximum number: 4,000 (typical yugioh ATK/DEF points range)". f. So in DBZ number group both power levels represent a character:
minimum number = 1 = DBZ character = 4-year old Gohan's power level (when not angry).
maxmimum number = 1,440,000 = DBZ character = Piccolo's power level after merging with Nail.
New number (1,200, remember?) = DBZ character = Saibaman's power level. (Yamcha you suck!)
g. And the "equivariant" in the Yugioh number group of DEF/ATK points would be:

Minimum number = 0 ATK points = power level of 1 (from the DBZ number group) = 4 year old gohan.
Maxmimum number = 4000 ATK points = power level of 1,440,000 (from the DBZ number group) = Piccolo after merging with Nail.
New number = 2000 ATK points = power level of 1,200 (from the DBZ group) = Saibaman. (Forget the joke with Yamcha) h. Now, since I want my game to have more than 1 deck, each deck must have a different minimum and maxmimum power levels, since each deck contains different DBZ characters than all the other decks, with different power levels. This means I need for my game several DBZ number groups for my game, and not just one DBZ group.
I also might (thought not neccesarily) need more than one Yugioh number group, if I want the decks to have different maximum and/or minimum ATK/DEF points.

i. I also calculate with the app each DBZ character's monster card's DEF points by providing the app another number that is a multiplication of its power level (always above 1). Than, the calculator calculates the DBZ character's DEF points equivariant by taking the result of the calculation (The character's power level x the another number), transforming the result to its ATK/DEF calculation, while this result represents the gap between the DBZ character's monster card's ATK and DEF points. The formula here is: ATK points + the gap between ATK/DEF. (It's addition because this gap is always suppose to be above 0 and never minus). Examples later.

i. So, I simply caluclate each DBZ character's ATK/DEF points equivariant, and than create its monster card and add it to its deck, to make the decks of the game.

And that's why I need this app to create my game.

Now, now the app can work with more than one "addition/subtraction" number group, and also with more than one "Multiplier" number group.
However, for the calculations this app does, we need to create a single group that represents the "link" and the connection between both number groups (both of the "multiplication/division" number group and the "addition/subtraction" number group).

Let's call this group "Link group" (In the software's code a link group is called "Deck").

The "Link group" contains the data of the minimum and maximum numbers of a "addition/subtraction" number group AND also the minimum and maximum numbers of a and the information that those groups are the equivariant of each other, and all the numbers in both of them. What does that mean? Say we have 2 "addition/subtraction" number groups and also 2 "multiplication/division" groups. The conversation between one number in a "multiplication/division" group's (we'll call this group A) equivariant number in a "addition/subtraction" number group (we'll call this group B), requires, as we saw earlier, knowing the minimum and maximum numbers of both groups A and B (which we need to know in advance, without any calculations, to calculate this).

So, for each number, when the conversation from its "multiplication/division" group number to its "addition/subtraction" group number equivariant is complete.. Say we want to convert it to its "addition/subtraction" group number's equivariant again, but for another "addition/subtraction" number group - let's call this group C. We can still convert the number from group A (the same "multiplication/division" group) to its equivariant in group C(another "multiplication/division" group), but the resulting number would, obviously, be different from the one we got after converting the number from group A to its group B equivariant.

That's why we need a "link group" where each number in its "multiplication/division" group would only have 1 equivariant in only one "addition/subtraction" number group. We don't each number to have many different equivariants - it's confusing as hell. In my opinion. Althought it's possible, and I probably only use "Link

Now, we can get to the the equations the console uses to do this conversation, via the 8 steps the console does to do its job. Spoiler alert: The mathematical calculations apppear in steps 3 and 5. The steps are:
1st step: the user gives the software the information only he can know: The minimum and maximum groups of a "multiplication/division" numbers AND those of a "addition/subtraction" numbers group. This was explained enough in section 10 already.

2nd step: the software creates a link group object (called "deck") instance based on the variables the user inputed to the console.

Third step: the software adds some more variables to the object that it must know to do the conversation:

a. The gap between the max number and minimum number in the "multiplication/division" group. This gap = maximum number / (divided by) minimum number.

b. Than, the console creates a special variable which we'll call "convert variable", which is the key variable to convert between the gaps in both groups. This number is the result of this calculation: 1 / (log(the gap from section a) / log(maximum number)) = the "convert variable". (I'll get to more in-depth explanations of this variable later. It is rather complicated. But if you're profund in mathematics, you might recognize a well-known mathematical formula here)

c. Also, the console creates objects represeting the minimum and maximum numbers, which include a property stating which link group they "belong" to.

4th step, The user inputs a number (let's call it "checked number"), to enter it into a "multiplication/division" group, and to find its equivariant in the "addition/subtraction" number group that is "linked" to the "multiplication/division" group via a single link group the console created in the third step above.

5th step, The software calculates this number's equivariant for the linked "addition/subtraction" number group via calculations in this order: a. calculating the gap between the "checked number" and the minimum number in the same "multiplication/division" group = checked number / minimum number. Let's call this gap "Above gap". b. after step a, it calculates another gap - we'll call it "ConvertedGap" - by calculating: above gap ^ convert variable (from step 3.b) = converted gap. c. after step b, it calculated the log difference between the checked number and the maximum number in the same "multiplication/division" group, by calculating: ((log(maximum number) / log(ConvertedGap)). we'll call the result "log difference". d. Finally, it reaches the checked's number equivariant for the linked "addition/subtraction" number group, by calculating this: maxiimum number / log difference.

6th step, the software saves the result of step d into the linked "addition/subtraction" number group. Obviously..

7th step: my console can also calculate another different number equivariant from the same "multiplication/division" group to the same "addition/subtraction" number group,

by writing another "checked number" (with a different value) that represents the gap (in multiplication/division) between it and the previous checked number. Than the console simply calculates the gap's "multiplication/division" group using (again) steps a-d from the 5th step, and adding the result to the previous checked's number equivariant in the linked "addition/subtraction" number group

8th step, there's a feature that allows the console to display all the information in its database in an organized way.

That's it.

(To be continued)
