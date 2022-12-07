using AutoMapper;
using Clinic.Entities.Models;
using Clinic.Repository;
using Clinic.Services.Abstract;
using Clinic.Services.Models;
using Clinic.Shared.Exceptions;
using Clinic.Shared.ResultCodes;

namespace Clinic.Services.Implementation;

public class UserService : IUserService
{
    private readonly IRepository<User> usersRepository;
    private readonly IMapper mapper;
    public UserService(IRepository<User> usersRepository, IMapper mapper)
    {
        this.usersRepository = usersRepository;
        this.mapper = mapper;
    }

    public void DeleteUser(Guid id)
    {
        var userToDelete = usersRepository.GetById(id);
        if (userToDelete == null)
        {
            throw new LogicException(ResultCode.USER_NOT_FOUND);
        }

        usersRepository.Delete(userToDelete);
    }

    public UserModel GetUser(Guid id)
    {
        var user = usersRepository.GetById(id);
        if (user == null)
        {
            throw new LogicException(ResultCode.USER_NOT_FOUND);
        }
        return mapper.Map<UserModel>(user);
    }

    public PageModel<UserPreviewModel> GetUsers(int limit = 20, int offset = 0)
    {
        var users = usersRepository.GetAll(); //query created
        int totalCount = users.Count();
        var chunk = users.OrderBy(x => x.Email).Skip(offset).Take(limit); //query updated IQueruable<User>

        return new PageModel<UserPreviewModel>()
        {
            Items = chunk.Select(x => mapper.Map<UserPreviewModel>(x)),
            TotalCount = totalCount
        };
    }

    public UserModel UpdateUser(Guid id, UpdateUserModel user)
    {
        var existingUser = usersRepository.GetById(id);
        if (existingUser == null)
        {
            throw new LogicException(ResultCode.USER_NOT_FOUND);
        }

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Patronymic = user.Patronymic;

        existingUser = usersRepository.Save(existingUser);
        return mapper.Map<UserModel>(existingUser);
    }

    public UserModel CreateUser(UserModel user)
    {
        return null;
        //1 валидация: проверка на уникальность
        // внешние ключи : валидация 
        // внешние ключи установка 
        // установка значений полей
        // репозиторий сохранение
        // 1 несколько воркфлоу : Регистрация пользователя: 
        // получение данных
        // 1 валидация пароля на символы, уникальность эмейла, непустота полей
        // 2 создание пользователя в базе
        // вернуть запись о пользователе
        // запись к врачу
        // 1 данные: id врача, дата и время, id пациента, id специальностей
        // 2 валидация данных: поля не пустые
        // 3 проверка прав пользователя: нет доступа,  
        // 4 валидация в сервисе:  айдишки, связи, свободность записи, пересечение записей,
        // 5 создание новой записи в бд
        // отправка уведомлений, эмейл с напоминание
        // 6 возвращаем пользователю запись 
    }
}