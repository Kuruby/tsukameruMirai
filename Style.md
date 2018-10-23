Class/Interface structure:

class
	constructor
	fields (int -> enum -> struct -> class -> Interface)
	   =>Accessors that are public encapsulations of fields go right after the field they do that to
	Accessors
	Methods

Interface is the same as class.

Interface names must start with I

class and namespace names beside the root must be capitalized.

Fields are lowercase, Accessors Capitalcase

getters/setters are always in the form
Accessor
{
	get=>get;
	set
	{
		set=value;
	}
}

Empty functions have their braces on the same line.
function f(){}