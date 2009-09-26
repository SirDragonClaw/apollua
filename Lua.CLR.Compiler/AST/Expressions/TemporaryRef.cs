// TemporaryRef.cs
//
// Lua 5.1 is copyright � 1994-2008 Lua.org, PUC-Rio, released under the MIT license
// LuaCLR is copyright � 2007-2008 Fabio Mascarenhas, released under the MIT license
// This version copyright � 2009 Edmund Kapusniak


using System;
using Lua.Compiler.Parser.AST;


namespace Lua.CLR.Compiler.AST.Expressions
{


public class TemporaryRef
	:	Expression
{
	public Temporary Temporary { get; private set; }


	public TemporaryRef( SourceSpan s, Temporary temporary )
		:	base( s )
	{
		Temporary = temporary;
	}


	public override void Accept( IExpressionVisitor v )
	{
		if ( v is ICLRExpressionVisitor )
		{
			( (ICLRExpressionVisitor)v ).Visit( this );
		}
	}

}


}