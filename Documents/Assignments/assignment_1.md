###### Assignment #1
## A SOLID start

### Goals:
Become familiar with and gain a hands-on experience with SOLID principles and some design patterns


### Task
In this assignment, we will create a simple file sharing and management system (like a Google Drive or Dropbox). Because our goal now is working with architectural challenges and not some framework based ones, our system will be local (meaning working on a single machine) and command-line based.

The task will be divided into few parts:

#### 1. Basic structure
Create a command-line program that supports next commands:
- `add <filename> <shortcut>` - adding a file to system with a name specified as "shortcut". If no shortcut is provided, use full filename (including a path) as a name;
- `remove <shortcut>` - remove a file;
- `list` - show a list of currently added files.

At this point, we don't need any persistence, so files will be lost when program finishes running. However, step will add a requirement of saving the system state, so you can think how ypu should write a system now to easily add persistence later.

#### 2. Extra operations
Add a `options <shortcut>` command that must show a list of available actions to perform on the specified file. This list must include a generic option `info` (view file size and location on a local computer) available for every file and some filetype-specific ones:
- `summary` for `.txt` files, showing basic information about text (number of symbols, words, paragraphs);
- `print` for an any `.csv` file, printing nicely formatted table to a screen;
- `print` for an any `.json` file, printing correctly indented json on a screen; 
- `validate` for a `.csv` and `.json` files

User can invoke an action by using `action <action_name> <shortcut>` command. Error must be shown if user tries to invoke a wrong command or invoke a command on unknown file.

#### 3. Few users
Rework your program to require using a `login <profilename>` command as a initial one in a session. User also can switch profiles during an active session by using the same command. Every profile must have separate files, new profile starts with an empty account.

#### 4. Different plans with limits
Now, let`s make system more interesting. We will have two plans: Basic and Gold, every user will start with Basic plan. 

Basic plan allows a user to have maximum 10 files AND maximum of 100Mb in a system. A special error message must be shown if user will try to exceed those limits.

Gold users will have 100 files and 1Gb respectively.

Users can change their plans by using `change_plan <plan_name>` command. If user is downgrading to Basic plan while having more than 100Mb of files and\or 10 files total an error must be shown with suggestion to user to remove extra files at first.

#### 5. Session saving
Our MVP performed well, so it is a time to add a persistence - profiles, plans and files must exist between sessions. In this step requirements are: 1) No other external software must be required to be installed on an end machine (like databases) except of .Net framework, 2) Program should not depend on an internet connection and must work offline.

If you've designed step 1 well, changes required to implement this one would be only to reimplement few interfaces.

#### 6. Analyse it!
Nowadays, apps collect A LOT of telemetry. Almost any user action is collected and reported to a bunch of specific services to aggregate and analyze (Firebase with BigQuery, Amplitude etc.)

In our system we will emulate this through logging events to a file. Every event will be represented as a JSON object:
```
{
    "event" : <name>,
    "timestamp" : <collection_time>,
    "params" : 
    {   
        <param_name> : <param_value>
    }
}
```
Types of events to collect are:

|          event_name | parameters                          |
|--------------------:|-------------------------------------|
|      user_logged_in | user_name                           |
|          file_added | shortcut, filetype                  |
|        file_removed | shortcut, filetype                  |
| file_action_invoked | shortcut, action                    |
|        plan_changed | user_name, plan_name                |
|       limit_reached | limit_type: {storage, files_amount} |
You must implement this step without using any frameworks

#### 7 and 8. Extra features
As well as any real-world system, our little system will evolve over time, adding new features, changing old ones and extending it's functionality in other ways. You will be given two more tasks to implement in your system after finishing previous five, so keep that in mind and plan your time in the way to have st least one week to work on them

### Grading policy
Maximum points: 10
- 1 point for each successfully implemented step (points can be reduced due to code quality);
- 2 points for theoretical answers.

### Learning Materials
1. Course lectures 1-6;
2. Agile Software Development: paragraphs about SOLID principles.
