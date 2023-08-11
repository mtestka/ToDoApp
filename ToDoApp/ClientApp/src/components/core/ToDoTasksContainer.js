import React, { useState, useEffect } from 'react';
import ToDoTask from './ToDoTask';
import { FiCheckCircle, FiCircle } from "react-icons/fi";
import { useSharedState } from '../SharedStateProvider';

function ToDoTasksContainer(props) {

    const [tasks, setTasks] = useState([]);
    const { refreshFlag } = useSharedState();

    const getData = async () => {
        const response = await fetch('todo')
        const data = await response.json();
        setTasks(data);
    };

    useEffect(() => {
        getData();
    }, [refreshFlag])

    return (
        <div className="flex flex-col gap-4">
            {tasks && tasks.map((d, index) =>
                <ToDoTask task={d} key={d.id} />
            )}
        </div>
    );
}

export default ToDoTasksContainer;