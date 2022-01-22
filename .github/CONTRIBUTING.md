# Contributing

When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

Please note we have a [code of conduct](./CODE_OF_CONDUCT.md), please follow it in all your interactions with the project.

## Build and run application

The following commands will go from nothing to a running application in development mode.

```
git clone https://github.com/FantasticFiasco/mvvm-dialogs.git
cd mvvm-dialogs
dotnet cake .\build\build.cake --target=Build
```

## Pull Request Process

1. Run tests and ensure that they pass
1. Rebase and squash your commits with meaningful commit messages

## Commit Messages

Format of the commit message:
```
<type>(<scope>): <subject>

<body>

<footer>
```

### Message subject (first line)

The first line cannot be longer than 70 characters, the second line is always blank and other lines should be wrapped at 80 characters. The type and scope should always be lowercase as shown below.

#### Allowed `<type>` values:

- __feat__ - new feature for the user, not a new feature for build script
- __fix__ - bug fix for the user, not a fix to a build script
- __docs__ - changes to the documentation
- __style__ - formatting, missing semi colons, etc; no production code change
- __refactor__ - refactoring production code, eg. renaming a variable
- __test__ - adding missing tests, refactoring tests; no production code change
- __chore__ - updating grunt tasks etc; no production code change

#### Example `<scope>` values:

- init
- runner
- watcher
- config
- web-server
- proxy
- etc.

The `<scope>` can be empty (e.g. if the change is a global or difficult to assign to a single component), in which case the parentheses are omitted.

### Message body

- uses the imperative, present tense: "change" not "changed" nor "changes"
- includes motivation for the change and contrasts with previous behavior

For more info about message body, see:

- http://365git.tumblr.com/post/3308646748/writing-git-commit-messages
- http://tbaggery.com/2008/04/19/a-note-about-git-commit-messages.html

### Message footer

#### Referencing issues

Closed issues should be listed on a separate line in the footer prefixed with "Closes" keyword like this:

```
Closes #234
```

or in the case of multiple issues:

```
Closes #123
Closes #245
Closes #992
```

This document is based on [AngularJS Git Commit Msg Convention](https://docs.google.com/document/d/1QrDFcIiPjSLDn3EL15IJygNPiHORgU1_OOAqWjiDU5Y/edit#).
