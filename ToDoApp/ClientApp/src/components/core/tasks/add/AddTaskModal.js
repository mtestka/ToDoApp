import AddTaskForm from './AddTaskForm'
import FormModal from '../../FormModal'

function AddTaskModal(props) {
    return (
        <FormModal setOpen={props.setOpen} open={props.open} form={"addTaskForm"} acceptButtonTitle={"Add"} title={"Add task"}>
            <AddTaskForm onSubmit={() => props.setOpen(false)} />
        </FormModal>
    )
}

export default AddTaskModal;