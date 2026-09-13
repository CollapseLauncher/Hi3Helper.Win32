using System;

namespace Hi3Helper.Win32.Native.Enums;

[Flags]
public enum TASK_CREATION
{
    /// <summary>The Task Scheduler service registers the task as a new task.</summary>
    Create = 2,

    /// <summary>
    /// The Task Scheduler service either registers the task as a new task or as an updated version if the task already exists.
    /// Equivalent to Create | Update.
    /// </summary>
    CreateOrUpdate = 6,

    /// <summary>
    /// The Task Scheduler service registers the disabled task. A disabled task cannot run until it is enabled. For more information,
    /// see Enabled Property of TaskSettings and Enabled Property of RegisteredTask.
    /// </summary>
    Disable = 8,

    /// <summary>
    /// The Task Scheduler service is prevented from adding the allow access-control entry (ACE) for the context principal. When the
    /// TaskFolder.RegisterTaskDefinition or TaskFolder.RegisterTask functions are called with this flag to update a task, the Task
    /// Scheduler service does not add the ACE for the new context principal and does not remove the ACE from the old context principal.
    /// </summary>
    DontAddPrincipalAce = 0x10,

    /// <summary>
    /// The Task Scheduler service creates the task, but ignores the registration triggers in the task. By ignoring the registration
    /// triggers, the task will not execute when it is registered unless a time-based trigger causes it to execute on registration.
    /// </summary>
    IgnoreRegistrationTriggers = 0x20,

    /// <summary>
    /// The Task Scheduler service registers the task as an updated version of an existing task. When a task with a registration trigger
    /// is updated, the task will execute after the update occurs.
    /// </summary>
    Update = 4,

    /// <summary>
    /// The Task Scheduler service checks the syntax of the XML that describes the task but does not register the task. This constant
    /// cannot be combined with the Create, Update, or CreateOrUpdate values.
    /// </summary>
    ValidateOnly = 1
}
