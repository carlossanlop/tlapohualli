# Tlapohualli
 
Console program that receives an integer number and returns its base 20 Nahuatl translation.

Written in C# using .NET 5.0.

# Usage

1. Build the program with Visual Studio, or from console using `dotnet build`.
2. Run the program using `dotnet run`.
3. The tool will ask you to type a number from 0 to 3,199,999.
4. To exit, type 'quit'.

# Introduction

Nahuatl is the language of the Aztec empire.

Tlapohualli means **numbers** in Nahuatl.

Unlike most modern societies, who use a base 10 numeral system, the Aztecs used a base 20 numeral system. They chose this base because they used their fingers and toes for counting.

Numbers in Nahuatl involve addition, multiplication and division on the go. This complexity is what motivated me to write this program.

# How their number system works

The Aztecs did not have a written language. After the conquest, the Spanish priests were the ones who wrote down the Aztec language, using (mostly) rules borrowed from the Spanish language, plus a few others they had to make up to represent some sounds that do not exist in Spanish.

The numbers 1 to 4 belong to their own special group:

- 1 = Ce
- 2 = Ome
- 3 = Yei
- 4 = Nahui

Number 5 has a unique name:

- 5 = Macuilli

Numbers 6 to 9 reuse the names of the numbers 1 to 4, but with a shared prefix, which indicates they are the numbers after 5:

- 6 = Chicuace
- 7 = Chicome
- 8 = Chicuei
- 9 = Chicnahui

Number 10 also has a unique name:

- 10 = Mahtlahtli

Numbers 11 to 14 reuse numbers 1 to 4, just like 6 to 9, but with the big difference that these are explicitly preceded by the number 10. Think of this as an addition (10+1, 10+2, 10+3, 10+4):

- 11 = Mahtlahtlin ce
- 12 = Mahtlahtlin ome
- 13 = Mahtlahtlin yei
- 14 = Mahtlahtlin nahui

Notice the word Mahtlatli ends with an **n** when it's used as a prefix.

Number 15 is another number with a unique name:

- 15 = Caxtollin

And the same rule we used for 10 to 14 is used with 16 to 19 (15+1, 15+2, 15+3, 15+4):

- 16 = Caxtollin ce
- 17 = Caxtollin ome
- 18 = Caxtollin yei
- 19 = Caxtollin nahui

And here is where we encounter the first number of the base 20 numeral system:

- 20 = **Cempohualli**

From now on, the rules of addition you saw from 1 to 19 are reused, with the small difference that the word **huan**, which means **and**, joins the base number (20 in this case) with the rest:

- 21 = Cempohualli huan ce
- 22 = Cempohualli huan ome
- 23 = Cempohualli huan yei
- 24 = Cempohualli huan nahui
- 25 = Cempohualli huan macuilli
- 26 = Cempohualli huan chicuace
- 27 = Cempohualli huan chicome
- 28 = Cempohualli huan chicuei
- 29 = Cempohualli huan chicnahui

- 30 = Cempohualli huan mahtlahtli
- 31 = Cempohualli huan mahtlahtlin ce
- 32 = Cempohualli huan mahtlahtlin ome
- 33 = Cempohualli huan mahtlahtlin yei
- 34 = Cempohualli huan mahtlahtlin nahui
- 35 = Cempohualli huan caxtollin (20 + 15)
- 36 = Cempohualli huan caxtollin ce
- 37 = Cempohualli huan caxtollin ome
- 38 = Cempohualli huan caxtollin yei
- 39 = Cempohualli huan caxtollin nahui

When you reach a multiple of 20, you precede it by a number from 1 to 19 to **multiply** it:

- 40 = Ome cempohualli (2 x 20)

Another way to understand this: when a smaller number precedes a larger number, you multiply them. When a larger number precedes a smaller number (or is joined by **huan**), you add them:

- 41 = Ome cempohualli huan ce (2 x 20 + 1)

  ...

- 50 = Ome cempohualli huan mahtlahtli (2 x 20 + 10)

  ...

- 60 = Yei cempohualli (3 x 20)

  ...

- 100 = Macuilli cempohualli (5 x 20)

  ...

- 200 = Mahtlahtli cempohualli (10 x 20)

  ...

- 300 = Caxtollin cempohualli (15 x 20)

  ...

- 399 = Caxtollin nahui cempohualli huan mahtlahtli nahui (19 x 20 + 10 + 9)

And then, you reach 400. Since this is a base 20 system, there can't be a 20 x 20. Instead, 400 has it's own unique word:

- 400 = **Cenzontli**

Here starts the creativity: you need to perform a division, then use the divisor, the quotient and the remainder to indicate the number. Format: `Quotient` `divisor` `huan` `remainder`

- 401 = Ce cenzontli huan ce (1quotient x 400divisor + 1remainder)
- 402 = Ce cenzontli huan ome (1 x 400 + 2)

  ...

- 500 = Ce cenzontli huan macuilli cempohualli (1 x 400 + 5 x 20)

  ...

- 700 = Ce cenzontli huan caxtollin cempohualli (1 x 400 + 15 x 20)

  ...

- 800 = Ome cenzontli (2 x 400)

  ...

- 1,000 = Ome cenzontli huan mahtlahtli cempohualli (2 x 400 + 10 x 20)

  ...

- 2,000 = Macuilli cempohualli (5 x 400)

  ...

400x20 is 8,000. The name for that number is:

- 8,000 = **Xiquipilli**

From now on, in most cases you'll have to do two separate divisions, since the first remainder must be explained too: Format: `Quotient1` x `divisor1` `huan` `remainder1` `quotient2` x `divisor2` + `remainder2`

- 8,001 = Ce xiquipilli huan ome (1 x 8000 + 1) (This is an exception to the format, because the remainder can be explained directly)

  ...

- 9,000 = Ce xiquipilli huan ome cenzontli huan mahtlahtli cempohualli (1 x 8,000 + 1 x 400 + 10 x 20 - The remainder is 9,000/8,000 es 1,000, and that number must be explained in the second division)

  ...

- 10,000 = Ce xiquipilli huan macuilli cempohualli (1 x 8000 + 5 x 400) (The remainder is 2,000)

  ...

There's one problem: there is no (known) Nahuatl word to describe 20 x 8,000 = 160,000. However, there are ways to explain that number, because every multiple of 20 has its own meaning:

a) Cempohualli: Means twenty or multiple.

b) Cenzontli: Means four hundred, but it comes from tzontli (hair), because they thought 400 was the number of hairs that we have on the head, or the number of sounds that can be emitted by the cenzontli or cenzontle, the unmistakable bird that Nezahualcoyotl mentions in his poem "My brother, the human". This poem used to be printed in the 100 Mexican pesos bill, so it is well known by most Mexicans.

c) Xiquipilli: Means eight hundred, but it also means bag or sack. It was thought that 8,000 is the amount of seeds (cocoa, beans, etc.) that fit in a sack.

To represent the number 160,000, my Nahuatl teacher's teacher, Genaro Medina Ramos, unoficially proposed to use the word **Xochiti**. It means "to transform oneself into a flower" [_\*\*citation needed\*\* - I learned this word a long time ago, I'm not entirely sure of the meaning_].

I decided to also use that word in the tool, which means the largest number the tool can translate is (160000 * 20) - 1 = 3,199,999.
