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
*Output*
```
True
True
True
False
Script ran: 0.01 seconds
```
#### Strings
```
// Strings
set("a", "part1");
set("b", "part2");
echoln(concat(get("a"), get("b")));
// String repeat
echoln(rep("a", "3"));
// String equality
echoln(eqs("1", "2"));
```
*Output*
```
part1part2
aaa
False
Script ran: 0.00 seconds
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
*Output*
```
3
-1
2
0.5
0.5
Script ran: 0.00 seconds
```

#### Logic
```
// Logic
echoln(or(true(), "False"));
echoln(or(false(), "False"));
```
*Output*
```
True
False
Script ran: 0.00 seconds
```

#### Conditionals
```
// Conditionals
if (eq("2", add("1", "1")))
{
  echoln("One plus one is two");
}
```
*Output*
```
One plus one is two
Script ran: 0.00 seconds
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
*Output*
```
Loop 1
Loop 2
Loop 3
Script ran: 0.00 seconds
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
*Output*
```
Goto 1
Goto 2
Goto 3
Script ran: 0.04 seconds
```

![Example](https://raw.githubusercontent.com/kristofferkjeldby/Script/main/readme.png)
