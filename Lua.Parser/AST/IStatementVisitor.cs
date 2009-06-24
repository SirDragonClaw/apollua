// IStatementVisitor.cs
//
// Lua 5.1 is copyright � 1994-2008 Lua.org, PUC-Rio, released under the MIT license
// LuaCLR is copyright � 2007-2008 Fabio Mascarenhas, released under the MIT license
// This version copyright � 2009 Edmund Kapusniak


using System;
using Lua.Parser.AST.Statements;


namespace Lua.Parser.AST
{


public interface IStatementVisitor
{
	void Visit( Assign s );
	void Visit( AssignList s );
	void Visit( Block s );
	void Visit( Branch s );
	void Visit( Declare s );
	void Visit( DeclareList s );
	void Visit( Evaluate s );
	void Visit( ForBlock s );
	void Visit( ForListBlock s );
	void Visit( MarkLabel s );
	void Visit( Return s );
	void Visit( ReturnList s );
	void Visit( Test s );
}


}

