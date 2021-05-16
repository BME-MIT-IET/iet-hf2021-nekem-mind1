Feature: RDFSharp

Scenario: Create a Triple
    Given a resource https://en.wikipedia.org/wiki/Leonardo_da_Vinci
    And a resource http://xmlns.com/foaf/spec/#term_maker
    And a string literal Mona_Lisa
    And they form a triple
    Then the triple will be created
    
Scenario: Create graphs
    Given there are 7 triples filled with test data
    Given there are 3 graphs
    And graph 1 contains triples 1 to 3
    And graph 2 contains triples 3 to 5
    And graph 3 contains triples 5 to 7
    Then graph 1 contains triple 1
    And graph 1 contains triple 2
    And graph 1 contains triple 3
    And graph 2 contains triple 3
    And graph 2 contains triple 4
    And graph 2 contains triple 5
    And graph 3 contains triple 5
    And graph 3 contains triple 6
    And graph 3 contains triple 7
    
Scenario: Remove triples by plain literal
    Given there are 3 triples
    And triple 1 is (R:https://en.wikipedia.org/wiki/Pablo_Picasso R:http://xmlns.com/foaf/spec/#term_maker T:La Vie:FR)
    And triple 2 is (R:https://en.wikipedia.org/wiki/Impression,_Sunrise R:http://xmlns.com/foaf/spec/#term_made T:Claude Monet:FR)
    And triple 3 is (R:https://en.wikipedia.org/wiki/Cecily_Brown R:http://xmlns.com/foaf/spec/#term_age N:52)
    Given there are 1 graphs
    And graph 1 contains triples 1 to 3
    When literal T:La Vie:FR is removed from graph 1
    Then graph 1 size is 2
    And graph 1 does not contain triple 1
    
Scenario: Clear graph
     Given there are 6 triples filled with test data
     Given there are 1 graphs
     And graph 1 contains triples 1 to 6
     When graph 1 is cleared
     Then graph 1 size is 0
        
Scenario: Select by subject
    Given there are 3 triples
    And triple 1 is (R:https://en.wikipedia.org/wiki/Pablo_Picasso R:http://xmlns.com/foaf/spec/#term_maker T:La Vie:fr-FR)
    And triple 2 is (R:https://en.wikipedia.org/wiki/Impression,_Sunrise R:http://xmlns.com/foaf/spec/#term_made T:Claude Monet:fr-FR)
    And triple 3 is (R:https://en.wikipedia.org/wiki/Pablo_Picasso R:http://xmlns.com/foaf/spec/#term_age N:140)
    Given there are 2 graphs
    And graph 1 contains triples 1 to 3
    When graph 2 is the result of selecting subject R:https://en.wikipedia.org/wiki/Pablo_Picasso from graph 1
    Then graph 2 size is 2
    And graph 2 contains triple 1
    And graph 2 contains triple 3
        
Scenario: Difference of two graphs
    Given there are 9 triples filled with test data
    Given there are 3 graphs
    And graph 1 contains triples 1 to 6
    And graph 2 contains triples 4 to 9
    When graph 3 is the difference of graph 1 and graph 2
    Then graph 3 size is 3
    And graph 3 contains triple 1
    And graph 3 contains triple 2
    And graph 3 contains triple 3