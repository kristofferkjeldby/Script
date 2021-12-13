# Script
A parser/interpreter for a simple script language

![Example](https://raw.githubusercontent.com/kristofferkjeldby/Script/main/logo.png)

#### Variables
```
// Variable scope

set("global", "1");
{
  set("local", "2");
  echoln(isset("global"));
  echoln(isset("local"));
}
echoln(isset("global"));
echoln(isset("local"));
```

#### Math
```
// Math
echoln(add("1", "2"));
echoln(sub("1", "2"));
echoln(mul("1", "2"));
echoln(div("1", "2"));
echoln(mod("10.5", "5"));
```

#### Logic
```
// Logic
echoln(or(true(), "False"));
echoln(or(false(), "False"));
```

#### Conditionals
```
// Conditionals
if (eq("2", add("1", "1")))
{
  echoln("One plus one is two");
}
```

#### Loops
```
// Loops
set("c", "1");
while (lt(get("c"), "4"))
{
  echoln(concat("Loop ", get("c")));
  set("c", add(get("c"), "1"));
}
```

#### Label/Goto
```
// Labels/Goto
set("d", "1");
label 1;
echoln(concat("Goto ", get("d")));
set("d", add(get("d"), "1"));
if (lt(get("d"), "4"))
{
  goto 1;
}
```

![Example](https://raw.githubusercontent.com/kristofferkjeldby/Script/main/readme.png)
