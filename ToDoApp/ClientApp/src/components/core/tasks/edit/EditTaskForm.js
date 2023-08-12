import { useState, useEffect } from 'react';
import { PhotoIcon, UserCircleIcon } from '@heroicons/react/24/solid';
import { useSharedState } from '../../../SharedStateProvider';

function EditTaskForm(props) {

    const { refreshFlag, setRefreshFlag } = useSharedState();

    const curr = new Date();
    const date = curr.toISOString().substring(0, 10);

    const [task, setTask] = useState({});

    const getData = async () => {
        const response = await fetch('todo/' + props.id);
        const data = await response.json();
        console.log(data.eventDate.split('T')[0]);
        setTask(data);
    };

    useEffect(() => {
        getData();
    }, [props.id])

    let handleSubmit = async (e) => {
        e.preventDefault();

        const formData = new FormData(document.querySelector("form"))

        try {
            let res = await fetch("todo", {
                method: "PUT",
                body: formData
            });

            if (res.status === 200) {
                props.onSubmit();
                setRefreshFlag(!refreshFlag);
            } else {
                console.log("There was an error!");
            }

        } catch (err) {
            console.log(err);
        }

        return;
    };

    return (
        <div>
            {task.eventDate &&
                <form id="editTaskForm" className="w-full space-y-4" onSubmit={handleSubmit}>
                    <input
                        type="hidden"
                        name="id"
                        defaultValue={task.id}
                        required
                    />
                    <div className="sm:col-span-full">
                        <label htmlFor="name" className="block text-sm font-medium leading-6 text-gray-900">
                            Task name
                            </label>
                        <div className="mt-2">
                            <input
                                type="text"
                                name="name"
                                id="name"
                                autoComplete="name"
                                className="block w-full flex-1 border-0 bg-transparent py-1.5 px-2 text-gray-900 placeholder:text-gray-400 focus:ring-0 sm:text-sm sm:leading-6"
                                placeholder="New task!"
                                defaultValue={task.name}
                                required
                            />
                        </div>
                    </div>
                    <div className="col-span-full">
                        <label htmlFor="description" className="block text-sm font-medium leading-6 text-gray-900">
                            Description
                            </label>
                        <div className="mt-2">
                            <textarea
                                id="description"
                                name="description"
                                rows={3}
                                className="block w-full rounded-md border-0 py-1.5 px-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                                defaultValue={task.description}
                                placeholder='Add some description'
                            />
                        </div>
                    </div>
                    <div className="col-span-full">
                        <label htmlFor="eventDate" className="block text-sm font-medium leading-6 text-gray-900">
                            Date
                </label>
                        <div className="mt-2">
                            <input
                                type="date"
                                name="eventDate"
                                defaultValue={task.eventDate.split('T')[0]}
                                id="eventDate"
                                className="block w-full flex-1 border-0 bg-transparent py-1.5 pl-1 text-gray-900 placeholder:text-gray-400 focus:ring-0 sm:text-sm sm:leading-6"
                            />
                        </div>
                    </div>
                    <div className="sm:col-span-full">
                        <label htmlFor="color" className="block text-sm font-medium leading-6 text-gray-900">
                            Color
                </label>
                        <div className="mt-2">
                            <select
                                id="color"
                                name="color"
                                className="w-full"
                                defaultValue={task.color}
                            >
                                <option value="0">Default</option>
                                <option value="1">Blue</option>
                                <option value="2">Red</option>
                                <option value="3">Green</option>
                                <option value="4">Yellow</option>
                            </select>
                        </div>
                    </div>
                    <div className="sm:col-span-full">
                        <div className="flex">
                            <div className="flex h-6 items-center mr-4">
                                <input
                                id="notify"
                                name="notify"
                                type="checkbox"
                                value="true"
                                className="h-4 w-4 rounded border-gray-300 text-indigo-600 focus:ring-indigo-600"
                                defaultChecked={task.notify}
                                />
                                <input

                                    type="hidden"
                                    name="notify"
                                    value="false"
                                />
                            </div>
                            <div className="text-sm leading-6">
                                <label htmlFor="offers" className="font-medium text-gray-900">
                                    Show notification on date?
                        </label>
                            </div>
                        </div>
                        <p className="text-gray-500 text-sm">Get notified when task should be done.</p>
                    </div>
                </form>
            }
        </div>
    )
}

export default EditTaskForm;