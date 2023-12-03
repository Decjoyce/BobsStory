What's up? #speaker:Tom #decay:3
->Choice01
== Choice01 ==
    +[Hey]
        -> Response01_01
    +[Not much bro]
        -> Response01_02
    +[Oh, nothing...]
        -> Response01_03
        
=== Response01_01 ===
What do you want?
    -> Choice02
=== Response01_02 ===
Cool
    -> Choice02
=== Response01_03 ===
Then what do you want?
    -> Choice02

== Choice02 ==
    +[Talk about football]
        -> Choice02_01
    +[Talk about school]
        -> Choice02_02
    +[Talk about the weather]
        -> Choice02_03
    +[Tell a joke]
    -> Choice02_04
    
=== Choice02_01 ===
#confidence:5
    +[What team do yous support?]
        -> Choice03_04
    +[Did yous see the United game last night?]
        -> Choice03_04
    +[Football is so dumb amirite?]
        -> Choice03_04

=== Choice02_02 ===
#confidence:2
    +[Geography's poxy, init]
        -> Choice03_04
    +[This place is a proper kip, init]
        -> Choice03_04
    +[The school's great!]
        -> Choice03_04
        
=== Choice02_03 ===
#confidence:-50
    +[Lovely weather we're having right?]
        -> Choice03_04
    +[The weather is so bad]
        -> Choice03_04
    +[Nevermind]
        -> Choice03_04

=== Choice02_04 ===
    +[Why'd the chicken cross the road?]
        -> Choice03_04
    +[Knock-Knock]
        -> Choice03_04
        

=== Choice03_04 ===
Then what do you want?
    -> END
