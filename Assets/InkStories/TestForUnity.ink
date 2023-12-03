What do you want? #speaker:Jerry
->My_Choices
== My_Choices ==
    + [Hey] 
        -> chosen("Polite")
    + [Hi] 
        -> chosen("Formal")
    + [What's up?] 
        -> chosen("Imformal")
    + [Bon Journo?] 
        -> chosen("French")

=== chosen(greeting) ===
What did you just say?!? #confidence:-10 #decay:5
->My_Choices2
== My_Choices2 ==
    + [Waddup B] 
        -> chosen2("Polite")
    + [Waddup 5] 
        -> chosen2("Formal")
    + [OOdad] 
        -> chosen2("Imformal")
    + [eej] 
        -> chosen2("French")
=== chosen2(dw) ===
Good idea! #end:
->END
