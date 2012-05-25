﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using ICSharpCode.SharpDevelop.Dom;

namespace ICSharpCode.PackageManagement.EnvDTE
{
	public class CodeNamespace : CodeElement
	{
		NamespaceName namespaceName;
		IProjectContent projectContent;
		CodeElementsInNamespace members;
		
		public CodeNamespace(IProjectContent projectContent, string qualifiedName)
			: this(projectContent, new NamespaceName(qualifiedName))
		{
		}
		
		public CodeNamespace(IProjectContent projectContent, NamespaceName namespaceName)
			: base(null)
		{
			this.projectContent = projectContent;
			this.namespaceName = namespaceName;
			this.InfoLocation = vsCMInfoLocation.vsCMInfoLocationExternal;
		}
		
		internal string QualifiedName {
			get { return namespaceName.QualifiedName; }
		}
		
		internal NamespaceName NamespaceName {
			get { return namespaceName; }
		}
		
		public string FullName {
			get { return this.Name; }
		}
		
		public override string Name {
			get { return namespaceName.LastPart; }
		}
		
		public CodeElements Members {
			get { 
				if (members == null) {
					members = new CodeElementsInNamespace(projectContent, namespaceName);
				}
				return members;
			}
		}
	}
}
