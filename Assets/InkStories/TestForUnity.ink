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
You chose {greeting}!
    -> END
