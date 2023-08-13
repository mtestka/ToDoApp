import React, { useState, useEffect } from 'react';
import ToDoTask from './ToDoTask';
import { FiCheckCircle, FiCircle } from "react-icons/fi";
import { useSharedState } from '../SharedStateProvider';
import EditTaskModal from './tasks/edit/EditTaskModal';

function ToDoTasksContainer(props) {

    const [tasks, setTasks] = useState([]);
    const [taskId, setTaskId] = useState(0);
    const [openEditTaskModal, setOpenEditTaskModal] = useState(false);
    const { refreshFlag } = useSharedState();

    const getData = async () => {
        const response = await fetch('todo?date='+props.date)
        const data = await response.json();
        setTasks(data);
    };

    useEffect(() => {
        getData();
    }, [refreshFlag, props.date])

    const handleTaskEdit = (id) => {
        setTaskId(id);
        setOpenEditTaskModal(true);
    }

    return (
        <div>
            <ul className="flex flex-col gap-4">
                {tasks && tasks.sort((a, b) => {
                    // First, compare by isCompleted (true comes before false)
                    if (a.isCompleted !== b.isCompleted) {
                        return a.isCompleted ? 1 : -1;
                    }

                    // If isCompleted values are equal, compare by name
                    return a.name.localeCompare(b.name);
                }).map((d, index) =>
                    <li key={d.id}>
                        <ToDoTask task={d} handleOnClick={handleTaskEdit} />
                    </li>
                )}
            </ul>
            <EditTaskModal id={taskId} open={openEditTaskModal} setOpen={setOpenEditTaskModal} />
        </div>
        
    );
}

export default ToDoTasksContainer;