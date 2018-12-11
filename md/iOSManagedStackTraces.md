# Managed stack traces on iOS

When an exception occurs in managed code, the stack trace for the exception can help you understand the cause of the exception. However, the managed stack trace might not appear as expected in some cases on iOS, as explained below. The stack trace also varies depending on the Xcode build configuration.

## Debug builds

When you use the debug build configuration with iOS, IL2CPP should report a reliable managed stack trace, and include each managed method in the call stack. The stack trace does not include line numbers from the original C# source code.

## Release builds

When you use a release build configuration, IL2CPP might produce a call stack that’s missing one or more managed methods. This is because the C++ compiler has inlined the missing methods. Method inlining is usually good for performance at run time, but it can make call stacks more difficult to understand. IL2CPP always provides at least one managed method on the call stack. This is the method where the exception occurred. It also includes other methods if they are not inlined.

If you can reproduce an exception locally, use Xcode to determine which methods have been inlined. Run the application in Xcode using the release configuration and set an exception breakpoint. The native call stack view in Xcode should indicate which methods actually exist, and which have been inlined.

## Source code line numbers

IL2CPP call stacks do not include source code line number information in the debug or release configurations.

---

* <span class="page-edit"> 21 March 2018  <!-- include IncludeTextNewPageYesEdit --></span>