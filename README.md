# CheckoutOrderKata
Pillar Technology Kata

This program was made in Visual Studio 2017, so I would recommend using that to build/test it-it shouldn't reference any libraries out of the ordinary.

The class methods such as getTotal are meant to function as an API. I'm not sure if this is constitutes an API by your definition, if not I can refactor it. 

Also I did not implement the use case "Buy M, get N of equal or lesser value at x% off." That is because I would have to make a major rewrite to the code. I am able to make these changes if the examiner thinks it would help them judge my programming ability. I would have to store each purchased item individually in a collection called Items. Instead of iterating through the Receipt collection, I would iterate through the Specials collection, and mark down the items in the Items collection and then sum them in order to get the total. Also, I am not sure how exactly this particular special should be handled in ambiguous situations. Does the equal or lesser value include the markdown price? And if there are multiple items of equal or lesser value, can the user choose which one to discount?


