package com.example;

import org.junit.Before;
import org.junit.Test;
import org.mockito.internal.matchers.GreaterThan;
import org.mockito.internal.matchers.LessThan;

import static org.hamcrest.CoreMatchers.is;
import static org.hamcrest.Matchers.greaterThan;
import static org.hamcrest.Matchers.lessThan;
import static org.junit.Assert.assertThat;
import static org.junit.matchers.JUnitMatchers.containsString;

public class TestGreeter {

  private Greeter greeter;

  @Before
  public void setup() {
    greeter = new Greeter();
  }

  @Test
  public void greetShouldIncludeTheOneBeingGreeted() {
    String someone = "World";

    assertThat(greeter.greet(someone), containsString(someone));
  }

  @Test
  public void greetShouldIncludeGreetingPhrase0() {
    String someone = "World";

    assertThat(greeter.greet(someone).length(), is(greaterThan(someone.length())));
  }

    @Test
  public void greetShouldIncludeGreetingMessage1() {
    String someone = "World, Thanks you making me Happy";

    assertThat(greeter.greet(someone).length(), is(greaterThan(someone.length())));
  }
   @Test
  public void greetShouldIncludeGreetingPhrase2() {
    String someone = "World, jadymy dalej, wlazlem tu z terminala również i savuje ten plik";

    assertThat(greeter.greet(someone).length(), is(greaterThan(someone.length())));
  }

}
