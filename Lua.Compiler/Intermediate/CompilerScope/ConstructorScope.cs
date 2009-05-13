// ConstructorScope.cs
//
// Lua 5.1 is copyright � 1994-2008 Lua.org, PUC-Rio, released under the MIT license
// LuaCLR is copyright � 2007-2008 Fabio Mascarenhas, released under the MIT license
// Modifications copyright � 2009 Edmund Kapusniak


using System;
using Lua.Compiler.Frontend.AST;
using Lua.Compiler.Intermediate.IR.Expression;


namespace Lua.Compiler.Intermediate.CompilerScope
{


class ConstructorScope
	:	IRCompilerScope
{

	public ConstructorExpression Constructor	{ get; private set; }


	public ConstructorScope( ConstructorExpression constructor )
	{
		Constructor	= constructor;
	}

}



}
